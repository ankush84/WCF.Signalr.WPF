using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WcfService3
{
    public class MyHub1 : Hub
    {
        public MyHub1()
        {
           // var connection =new HubConnection("");
        }
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}