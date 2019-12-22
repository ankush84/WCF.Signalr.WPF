using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WcfService3.Startup1))]

namespace WcfService3
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            //var hubConfiguration = new HubConfiguration();
            app.MapSignalR();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
