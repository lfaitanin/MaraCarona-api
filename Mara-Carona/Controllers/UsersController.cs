using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mara_Carona.Context;
using Mara_Carona.Models;
using Microsoft.AspNetCore.Cors;

namespace Mara_Carona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context.AppContext _context;

        public UsersController(Context.AppContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getusers()
        {
            return _context.users.Include(club => club.Club)
                                  .Include(userType => userType.UserType)
                                  .ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userTipo = await _context.usersType.FindAsync(user.UserTypeId);
            var club = await _context.club.FindAsync(user.clubId);

            return CreatedAtAction("GetUser", new { id = user.Id, club = club.id, userType = userTipo.type }, user);

        }

        // GET: api/Users/5
        [HttpGet("/matchDay/{id}")]
        public IActionResult GetNextGame(int id)
        {

            var user = _context.users.Find(id);
            if (user == null)
            {
                return BadRequest();
            }
            var nextMatches = _context.fixture.Where(match => match.teamhomeid == user.clubId || match.teamawayid == user.clubId).ToList();
            var currentDate = DateTime.Today;
            Dictionary<int, double> busca = new Dictionary<int, double>();
            nextMatches.ForEach(m => busca.Add(m.id, (m.date - currentDate).TotalDays));
            busca.OrderBy(b => b.Value);

            var nextMatchId = busca.FirstOrDefault(x => x.Value > 0).Key;
            var nextMatch = nextMatches.FirstOrDefault(x => x.id == nextMatchId);
            
            if (nextMatch == null)
            {
                return BadRequest();
            }
            return Ok(nextMatch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        private bool UserExists(int id)
        {
            return _context.users.Any(e => e.Id == id);
        }
    }
}
