using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using SignalRClient.Entities;

namespace SignalRConsoleReceiverApp
{
    class Program
    {
        private static HubConnection _hubConnection;

        public static async Task Main(string[] args)
        {
            await StartConnection();

            // Keep the console application running
            Console.WriteLine("Listening for messages...");
            Console.WriteLine("Press Ctrl+C to exit.");
            await Task.Delay(-1);
        }

        public static async Task StartConnection()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7268/myhub") // Replace with your API URL
                .Build();

            _hubConnection.On<Message>("ReceiveMessage", message =>
            {
                Console.WriteLine($"Received message: {message}");
            });

            try
            {
                await _hubConnection.StartAsync();
                Console.WriteLine("Connection started");

                await GetConnectionId();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while starting connection: {ex.Message}");
            }
        }

        public static async Task GetConnectionId()
        {
            try
            {
                var connectionId = await _hubConnection.InvokeAsync<string>("GetConnectionId");
                Console.WriteLine($"Connection ID: {connectionId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while getting connection ID: {ex.Message}");
            }
        }
    }
}
