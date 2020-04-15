using Mara_Carona.Models;
using Mara_Carona.Models.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.Interfaces.BLL
{
    public interface IChatBLL
    {
        void SaveMessage(User userFrom, User userTo, string text);
        IEnumerable<Message> GetMessages(int userFromId, int userToId);
    }
}
