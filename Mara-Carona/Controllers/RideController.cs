using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mara_Carona.Interfaces.BLL;
using Mara_Carona.Models;
using Mara_Carona.Models.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mara_Carona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IRideBLL _rideBLL;

        public RideController(IRideBLL rideBLL)
        {
            _rideBLL = rideBLL;
        }

        // GET: api/Users
        [Route("GetByClub/{clubId}/{date}/{fixtureId}")]
        [HttpGet]
        public IActionResult GetByClub(int clubId, DateTime date, int fixtureId)
        {
            var ridersAvailable = _rideBLL.FindRideByClub(clubId, date, fixtureId);
            if(ridersAvailable == null)
            {
                return BadRequest();
            }
            return Ok(ridersAvailable);
        }

        [Route("GetRideByNbHood")]
        [HttpGet]
        public IActionResult FindRideByNbHood(string nbhood, DateTime date, int fixtureId)
        {
            var ridersAvailable = _rideBLL.FindRideByNbHood(nbhood, date, fixtureId);
            if (ridersAvailable == null)
            {
                return BadRequest();
            }
            return Ok(ridersAvailable);
        }

        [Route("GetRideByCity")]
        [HttpGet]
        public IActionResult FindRideByCity(string city, DateTime date, int fixtureId)
        {
            var ridersAvailable = _rideBLL.FindRideByCity(city, date, fixtureId);
            if (ridersAvailable == null)
            {
                return BadRequest();
            }
            return Ok(ridersAvailable);
        }

        [Route("ApplyForRide")]
        [HttpPost]
        public IActionResult ApplyForRide(int rideId, User passenger)
        {
            try
            {
                _rideBLL.ApplyForRide(rideId, passenger);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro no ApplyForRide: {e}, {e.StackTrace}");
                return BadRequest(e);
            }
        }

        [Route("ChangeRideUserStatus")]
        [HttpPost]
        public IActionResult ChangeRideUserStatus(int rideUserId, ApprovalStatus status)
        {
            try
            {
                _rideBLL.ChangeRideUserStatus(rideUserId, status);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro no ApplyForRide: {e}, {e.StackTrace}");
                return BadRequest(e);
            }
        }

        [Route("CreateRide/{ride}")]
        [HttpPost]
        public IActionResult PostMatch(Ride ride)
        {
            try
            {
                return Ok(_rideBLL.CreateRide(ride));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("UpdateRide/{ride}")]
        [HttpPost]
        public IActionResult UpdateRide(Ride ride)
        {
            try
            {
                return Ok(_rideBLL.UpdateRide(ride));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("DeleteRide/{ride}")]
        [HttpPost]
        public IActionResult DeleteRide(Ride ride)
        {
            try
            {
                _rideBLL.DeleteRide(ride);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

       
    }
}