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
using Mara_Carona.Data;
using Mara_Carona.BLL;

namespace Mara_Carona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBLL _userBLL;

        public UsersController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<User>> Getusers()
        {
            return await _userBLL.Getusers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userBLL.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            var userTipo = await _userBLL.GetTypeUser(user.Value);
            var club = await _userBLL.GetClub(user.Value);

            return CreatedAtAction("GetUser", new { id = user.Value.Id, club = club.Id, userType = userTipo.type }, user);

        }

        [HttpGet("{token}")]
        public ActionResult<User> GetUserByToken(string token)
        {
            var user = _userBLL.GetUserByToken(token);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new { Token = user.Token, Id = user.Id, Name = user.username, Email = user.email });
        }

        // GET: api/Users/5
        [HttpGet("/matchDay/{id}")]
        public async Task<IActionResult> GetNextGameAsync(int id)
        {

            var user = await _userBLL.GetUser(id);
            if (user == null)
            {
                return BadRequest();
            }
            var nextMatch = _userBLL.GetNextGame(user.Value);

            if (nextMatch == null)
            {
                return BadRequest();
            }
            return Ok(nextMatch);
        }


        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                _userBLL.createUser(user);

                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private bool UserExists(int id)
        {
            return _userBLL.UserExists(id);
        }
    }
}
