using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.Models.Hub
{
    public class Message
    {
        public int Id { get; set; }
        public User UserFrom { get; set; }
        public User UserTo { get; set; }
        public string Text { get; set; }
    }
}
