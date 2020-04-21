using Mara_Carona.Models.Enum;

namespace Mara_Carona.Models
{
    public class RideUser
    {
        public int Id { get; set; }
        public Ride Ride { get; set; }
        public int RideId { get; set; }
        public User Driver { get; set; }
        public int DriverId { get; set; }
        public User Passenger { get; set; }
        public int PassengerId { get; set; }
        public ApprovalStatus Status { get; set; }
    }
}
