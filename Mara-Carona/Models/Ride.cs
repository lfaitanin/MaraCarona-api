using System;
using System.Collections.Generic;

namespace Mara_Carona.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Fixture Fixture { get; set; }
        public int FixtureId { get; set; }
        public int Capacity { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public DateTime RideDate { get; set; }
        public List<RideUser> Passengers { get; set; }
    }
}
