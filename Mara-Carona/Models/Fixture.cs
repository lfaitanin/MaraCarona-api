using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.Models
{
    public class Fixture
    {
        public int Id { get; set; }
        public int teamhomeid { get; set; }
        public int teamawayid { get; set; }
        public string location { get; set; }
        public int competitionid { get; set; }
        public DateTime date { get; set; }
        public Club Club { get; set; }
        public int clubId { get; set; }
    }
}
