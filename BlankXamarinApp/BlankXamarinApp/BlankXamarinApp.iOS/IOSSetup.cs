using Autofac;
using BlankXamarinApp.Core;
using BlankXamarinApp.iOS.Services;
using XLabs.Platform.Device;

namespace BlankXamarinApp.iOS
{
    public class IOSSetup : AppSetup
    {
        protected override void RegisterDepenencies(ContainerBuilder cb)
        {
            base.RegisterDepenencies(cb);

            cb.RegisterType<IOSLogger>().As<IOSLogger>().SingleInstance();
			cb.RegisterType<SQLite_iOS>().As<ISQLite>().SingleInstance();
			cb.Register<IDevice>(t => AppleDevice.CurrentDevice);
        }
    }
}

