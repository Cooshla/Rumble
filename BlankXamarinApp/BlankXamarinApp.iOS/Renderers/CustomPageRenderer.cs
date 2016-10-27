using CoreGraphics;
using UIKit;

[assembly: Xamarin.Forms.ExportRenderer
    (
        typeof(Xamarin.Forms.Page),
        typeof(TheCaravanClub.iPhone.Renderers.CustomPageRenderer)
    )
]

namespace TheCaravanClub.iPhone.Renderers
{
    public class CustomPageRenderer : Xamarin.Forms.Platform.iOS.PageRenderer
    {
        private UIWebView FindWebView(UIView view)
        {
            if (view is UIWebView)
                return (UIWebView)view;

            foreach (UIView subview in view.Subviews)
            {
                UIWebView webView;

                if ((webView = FindWebView(subview)) != null)
                    return webView;
            }

            return null;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            UIWebView webView;

            if ((webView = FindWebView(base.View)) == null) return;

            webView.Frame
                = new CGRect
                    (
                    webView.Frame.X,
                    webView.Frame.Y,
                    webView.Frame.Width,
                    webView.Frame.Height - 1
                    );

            webView.Frame
                = new CGRect
                    (
                    webView.Frame.X,
                    webView.Frame.Y,
                    webView.Frame.Width,
                    webView.Frame.Height + 1
                    );
        }
    }
}