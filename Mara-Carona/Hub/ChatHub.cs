using Mara_Carona.Interfaces.BLL;
using Mara_Carona.Models;
using Microsoft.AspNetCore.SignalR;

namespace Mara_Carona.HubContext
{
    public class ChatHub : Hub
    {
        private readonly IChatBLL _chatBL;
        public ChatHub(IChatBLL chatBL)
        {
            _chatBL = chatBL;
        }

        public void Send(User userFrom, User userTo, string text)
        {
            _chatBL.SaveMessage(userFrom, userTo, text);
            Clients.All.SendAsync("send", userFrom, userTo, text);
        }
    }
}
