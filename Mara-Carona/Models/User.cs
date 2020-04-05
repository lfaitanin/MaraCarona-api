using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.Models
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string adress { get; set; }
        public Club Club { get; set; }
        public int clubId { get; set; }
        public UserType UserType { get; set; }
        public int UserTypeId { get; set; }

    }
}
