﻿using BlankXamarinApp.Core;
using Autofac;
using XLabs.Platform.Device;

namespace BlankXamarinApp.Droid
{
	public class DroidSetup : AppSetup
	{
		protected override void RegisterDepenencies(ContainerBuilder cb)
		{
			base.RegisterDepenencies(cb);

			//cb.RegisterType<DroidThemer>().As<IThemer>().SingleInstance(); //can't see what this does? class also commented out...
            cb.RegisterType<SQLite_Android>().As<ISQLite>().SingleInstance();
            cb.Register<IDevice>(t => AndroidDevice.CurrentDevice);
			
		}
	}
}

