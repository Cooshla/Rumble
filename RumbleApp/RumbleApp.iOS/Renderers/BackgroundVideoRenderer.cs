﻿using System;
using System.IO;
using JamnationApp.Core.Abstracts;
using RumbleApp.iPhone.Renderers;
using Foundation;
using MediaPlayer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BackgroundVideo), typeof(VideoRenderer))]
namespace RumbleApp.iPhone.Renderers
{
    public class VideoRenderer : ViewRenderer<BackgroundVideo, UIView>
    {
        MPMoviePlayerController videoPlayer;
        NSObject notification = null;

        void InitVideoPlayer()
        {
            var path = Path.Combine(NSBundle.MainBundle.BundlePath, Element.Source);

            if (!NSFileManager.DefaultManager.FileExists(path))
            {
                Console.WriteLine("Video not exist");
                videoPlayer = new MPMoviePlayerController();
                videoPlayer.ControlStyle = MPMovieControlStyle.None;
                videoPlayer.ScalingMode = MPMovieScalingMode.AspectFill;
                videoPlayer.RepeatMode = MPMovieRepeatMode.One;
                videoPlayer.View.BackgroundColor = UIColor.Clear;
                SetNativeControl(videoPlayer.View);
                return;
            }

            // Load the video from the app bundle.
            NSUrl videoURL = new NSUrl(path, false);

            // Create and configure the movie player.
            videoPlayer = new MPMoviePlayerController(videoURL);

            videoPlayer.ControlStyle = MPMovieControlStyle.None;
            videoPlayer.ScalingMode = MPMovieScalingMode.AspectFill;
            videoPlayer.RepeatMode = Element.Loop ? MPMovieRepeatMode.One : MPMovieRepeatMode.None;
            videoPlayer.View.BackgroundColor = UIColor.Clear;
            foreach (UIView subView in videoPlayer.View.Subviews)
            {
                subView.BackgroundColor = UIColor.Clear;
            }

            videoPlayer.PrepareToPlay();
            SetNativeControl(videoPlayer.View);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BackgroundVideo> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                InitVideoPlayer();
            }
            if (e.OldElement != null)
            {
                // Unsubscribe
                notification?.Dispose();
            }
            if (e.NewElement != null)
            {
                // Subscribe
                notification = MPMoviePlayerController.Notifications.ObservePlaybackDidFinish((sender, args) =>
                {
                    /* Access strongly typed args */
                    Console.WriteLine("Notification: {0}", args.Notification);
                    Console.WriteLine("FinishReason: {0}", args.FinishReason);

                    Element?.OnFinishedPlaying?.Invoke();
                });
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Element == null || Control == null)
                return;

            if (e.PropertyName == BackgroundVideo.SourceProperty.PropertyName)
            {
                InitVideoPlayer();
            }
            else if (e.PropertyName == BackgroundVideo.LoopProperty.PropertyName)
            {
                var liveImage = Element as BackgroundVideo;
                if (videoPlayer != null)
                    videoPlayer.RepeatMode = Element.Loop ? MPMovieRepeatMode.One : MPMovieRepeatMode.None;
            }
        }
    }
}