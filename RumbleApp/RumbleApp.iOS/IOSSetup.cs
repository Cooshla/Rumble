using Autofac;
using JamnationApp.Core;
using JamnationApp.Core.Interfaces;
using JamnationApp.iOS.Services;
using RumbleApp.iPhone.Controls;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace JamnationApp.iOS
{
    public class IOSSetup : AppSetup
    {
        protected override void RegisterDepenencies(ContainerBuilder cb)
        {
            base.RegisterDepenencies(cb);

            cb.RegisterType<MediaPicker>().As<IMediaPicker>();
            cb.RegisterType<IOSLogger>().As<IOSLogger>().SingleInstance();
			cb.RegisterType<SQLite_iOS>().As<ISQLite>().SingleInstance();
			cb.Register<IDevice>(t => AppleDevice.CurrentDevice);
            cb.RegisterType<ITwilioMessenger>().As<TwilioMessenger>().SingleInstance();
        }
    }
}

