using Mara_Carona.Models;
using Mara_Carona.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mara_Carona.Interfaces.BLL
{
    public interface IRideBLL
    {
        Task<ActionResult<Ride>> getMatchRiders(int matchId, int typeId);
        void createMatchRider(RideUser match);
        IEnumerable<Ride> FindRideByNbHood(string nbhood, DateTime date, int fixtureId);
        IEnumerable<Ride> FindRideByCity(string city, DateTime date, int fixtureId);
        IEnumerable<Ride> FindRideByClub(int clubId, DateTime date, int fixtureId);
        void ApplyForRide(int rideId, User passenger);
        void ChangeRideUserStatus(int rideUserId, ApprovalStatus status);
        Ride CreateRide(Ride ride);
        Ride UpdateRide(Ride ride);
        void DeleteRide(Ride ride);

    }
}
