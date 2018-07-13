using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using RumbleApp.Api.Providers;

[assembly: OwinStartup(typeof(JamnationApp.Api.Startup))]

namespace JamnationApp.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var idProvider = new CustomUserIdProvider();

           // GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);

            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
