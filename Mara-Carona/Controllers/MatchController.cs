using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mara_Carona.Interfaces.BLL;
using Mara_Carona.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mara_Carona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchBLL _matchBLL;

        public MatchController(IMatchBLL matchBLL)
        {
            _matchBLL = matchBLL;
        }

        // GET: api/Users
        [Route("GetRiders/{idMatch}/{idType}")]
        [HttpGet]
        public async Task<IActionResult> GetRiders(int idMatch, int idType)
        {
            var ridersAvailable = await _matchBLL.getMatchRiders(idMatch, idType);
            if(ridersAvailable == null)
            {
                return BadRequest();
            }
            return Ok(ridersAvailable);
        }

        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            try
            {
                _matchBLL.createMatchRider(match);

                return CreatedAtAction("CreateMatch", new { id = match.Id }, match);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}