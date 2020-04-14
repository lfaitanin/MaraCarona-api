using Microsoft.AspNetCore.SignalR;

namespace Mara_Carona.HubContext
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.SendAsync("send", name, message);
        }
    }
}
