using Ais.Agent.Executor.Service.Entities;
using Microsoft.AspNet.SignalR.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ais.Agent.Executor.Service.Services.CommunicationService
{
    public class SignalRClientService
    {
        private IHubProxy _hubProxy;
        private HubConnection _hubConnection;

        public async Task Start()
        {
            // Replace with your SignalR hub URL
            string hubUrl = "https://localhost:7268/myhub";

            // Create a connection
            _hubConnection = new HubConnection(hubUrl);

            // Create a proxy to the hub
            _hubProxy = _hubConnection.CreateHubProxy("myhub");

            // Define what to do when receiving messages from the hub
            _hubProxy.On<Message>("ReceiveMessage", message =>
            {
                Console.WriteLine($"Received message: {message}");
            });

            // Start the connection
            try
            {
                await _hubConnection.Start();
                Console.WriteLine("Connected to SignalR Hub.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to SignalR Hub: {ex.Message}");
            }
        }

        public async Task Stop()
        {
            if (_hubConnection != null)
            {
                _hubConnection.Stop();
                _hubConnection.Dispose();
            }
        }
    }
}
