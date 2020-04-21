using Mara_Carona.Interfaces.BLL;
using Mara_Carona.Models;
using Mara_Carona.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.BLL
{
    public class RideBLL : IRideBLL
    {
        private readonly Context.AppContextMaracarona _context;

        public RideBLL(Context.AppContextMaracarona context)
        {
            _context = context;
        }

        public Ride CreateRide(Ride ride)
        {
            _context.Ride.Add(ride);
            _context.SaveChanges();
            return ride;
        }

        public Ride UpdateRide(Ride ride)
        {
            _context.Ride.Update(ride);
            _context.SaveChanges();
            return ride;
        }

        public void DeleteRide(Ride ride)
        {
            _context.Ride.Remove(ride);
            _context.SaveChanges();
        }

        public IEnumerable<Ride> FindRideByNbHood(string nbhood, DateTime date, int fixtureId)
        {
            return _context.Ride.Where(x => x.Neighborhood == nbhood && x.Passengers.Count() < x.Capacity && x.RideDate == date && x.Fixture.id == fixtureId);
        }
        public IEnumerable<Ride> FindRideByCity(string city, DateTime date, int fixtureId)
        {
            return _context.Ride.Where(x => x.City == city && x.Passengers.Count() < x.Capacity && x.RideDate == date && x.Fixture.id == fixtureId);
        }
        public IEnumerable<Ride> FindRideByClub(int clubId, DateTime date, int fixtureId)
        {
            return _context.Ride.Where(x => x.User.Club.Id == clubId && x.Passengers.Count() < x.Capacity && x.RideDate == date && x.Fixture.id == fixtureId);
        }

        public void ApplyForRide(int rideId, User passenger)
        {
            var ride = _context.Ride.FirstOrDefault(x => x.Id == rideId);
            var rideUser = new RideUser
            {
                Driver = ride.User,
                Passenger = passenger,
                Ride = ride,
                Status = ApprovalStatus.Pending
            };

            _context.RideUser.Add(rideUser);
            _context.SaveChanges();
        }

        public void ChangeRideUserStatus(int rideUserId, ApprovalStatus status)
        {
            var rideUser = _context.RideUser.FirstOrDefault(x => x.Id == rideUserId);
            rideUser.Status = status;
            
            _context.RideUser.Update(rideUser);
            _context.SaveChanges();
        }

        public async Task<ActionResult<Ride>> getMatchRiders(int matchId, int typeId)
        {
            var user = await _context.Ride.Where(u => u.Id == matchId || u.User.UserTypeId != typeId).FirstAsync();
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public void createMatchRider(RideUser match)
        {
            _context.RideUser.Add(match);
            _context.SaveChanges();
        }
    }
}
