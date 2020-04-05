using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.Models
{
    public class Fixture
    {
        public int id { get; set; }
        public int teamhomeid { get; set; }
        public int teamawayid { get; set; }
        public string location { get; set; }
        public int competitionid { get; set; }
        public DateTime date { get; set; }
    }
}
