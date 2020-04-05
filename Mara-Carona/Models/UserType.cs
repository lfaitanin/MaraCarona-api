using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.Models
{
    public class UserType
    {
        public int UserTypeId { get; set; }
        public string type { get; set; }
    }
}
