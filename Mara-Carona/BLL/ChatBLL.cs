using Mara_Carona.Interfaces.BLL;
using Mara_Carona.Models;
using Mara_Carona.Models.Hub;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.BLL
{
    public class ChatBLL : IChatBLL
    {
        private readonly Context.AppContextMaracarona _context;
        public ChatBLL(Context.AppContextMaracarona context)
        {
            _context = context;
        }

        public void SaveMessage(User userFrom, User userTo, string text)
        {
            var user1 = _context.users.FirstOrDefault(x => x.Id == userFrom.Id);
            var user2 = _context.users.FirstOrDefault(x => x.Id == userTo.Id);
            var message = new Message
            {
                Text = text,
                UserFrom = user1,
                UserTo = user2
            };

            _context.Message.Add(message);
            _context.SaveChanges();
        }

        public IEnumerable<Message> GetMessages(int userFromId, int userToId)
        {
            return _context.Message.Where(x => x.UserFrom.Id == userFromId && x.UserTo.Id == userToId).ToList();
        }
    }
}
