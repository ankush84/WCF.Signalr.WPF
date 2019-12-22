using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HubConnection hubConnection;
        private IHubProxy HubProxy;

        public MainWindow()
        {
            InitializeComponent();

            StartHub();
        }

        private void StartHub()
        {
            hubConnection = new HubConnection("http://localhost:50196");

            HubProxy = hubConnection.CreateHubProxy("MyHub1");
            hubConnection.Start();
            Execute();

            HubProxy.Invoke("hello").Wait();

        }

        private void Execute()
        {

            hubConnection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());

                    return;
                }
                else
                {
                    Console.WriteLine("Connected to Server.The ConnectionID is:" + hubConnection.ConnectionId);

                }

            }).Wait();
        }
    }
}
