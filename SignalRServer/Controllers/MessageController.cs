using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.CommunicationHub;
using SignalRServer.Entities;
using System.Threading.Tasks;

namespace SignalRServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<MyHub> _hubContext;

        public MessageController(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("sendToClient")]
        public async Task<IActionResult> SendMessageToClient(string clientKey, [FromBody] Message message)
        {
            await _hubContext.Clients.Client(clientKey).SendAsync("ReceiveMessage",  message);
            return Ok("Message sent to specific client");
        }
    }
}
