using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SignalRServer.CommunicationHub
{
    public class MyHub : Hub
    {
        // Store client keys and their associated connection IDs
        private static readonly ConcurrentDictionary<string, string> ClientConnections = new ConcurrentDictionary<string, string>();
        public string GetConnectionId() => Context.ConnectionId;
        public async Task SendMessageToClient(string clientKey, string message)
        {
            if (ClientConnections.TryGetValue(clientKey, out var connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
            }
            else
            {
                await Clients.Caller.SendAsync("ReceiveMessage", "Client not found for the provided key.");
            }
        }
    }
}
