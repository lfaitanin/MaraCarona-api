using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.Models
{
    public class Match
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public int UserTypeId { get; set; }
        public Fixture Fixture { get; set; }
        public int FixtureId { get; set; }
    }
}
