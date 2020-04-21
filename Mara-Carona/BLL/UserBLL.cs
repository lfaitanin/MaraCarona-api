using Mara_Carona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly Context.AppContextMaracarona _context;

        public UserBLL(Context.AppContextMaracarona context)
        {
            _context = context;
        }

        public void createUser(User user)
        {
             _context.users.Add(user);
             _context.SaveChanges();
        }

        public void updateUser(User user)
        {
            _context.users.Update(user);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<User>> Getusers()
        {
            return _context.users.Include(club => club.Club)
                                  .Include(userType => userType.UserType)
                                  .ToList();
        }

        public async Task<ActionResult<User>> GetUser(string token)
        {
            var user = await _context.users.Where(u => u.Token == token).FirstAsync();
            if(user != null)
            {
                return user;
            }
            return null;
        }
        public User GetUserByEmail(string email)
        {
         
            var user = _context.users.Where(user => user.email == email).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public async Task<UserType> GetTypeUser(User user)
        {
            return await _context.usersType.FindAsync(user.UserTypeId);
        }

        public async Task<Club> GetClub(User user)
        {
            return await _context.club.FindAsync(user.clubId);
        }
        public object GetNextGame(User user)
        {
            var nextMatches = _context.fixture.Include(club => club.Club).Where(match => match.teamhomeid == user.clubId || match.teamawayid == user.clubId).ToList();
            var currentDate = DateTime.Today;
            Dictionary<int, double> busca = new Dictionary<int, double>();
            nextMatches.ForEach(m => busca.Add(m.id, (m.date - currentDate).TotalDays));
            busca.OrderBy(b => b.Value);

            var nextMatchId = busca.FirstOrDefault(x => x.Value > 0).Key;
            var nextMatch = nextMatches.FirstOrDefault(x => x.id == nextMatchId);
            var homeTeam = _context.club.FirstOrDefault(club => club.Id == nextMatch.teamhomeid);
            var awayTeam = _context.club.FirstOrDefault(club => club.Id == nextMatch.teamawayid);
            string[] result = {
              nextMatch.date.ToString(),
              nextMatch.location,
              homeTeam.name,
              awayTeam.name
            };

            var values = new
            {
                gameDate = nextMatch.date.ToString(),
                gameLocation = nextMatch.location,
                homeTeam = homeTeam.name,
                awayTeam = awayTeam.name
            };
            return values;
        }
        public List<User> GetCarona(User user)
        {
            var usuariosTorcedores = _context.users.Where(match => user.UserTypeId != match.UserTypeId && user.clubId == match.clubId).ToList();
            return usuariosTorcedores;
        }
        public bool UserExists(int id)
        {
            return _context.users.Any(e => e.Id == id);
        }

        public User GetUserByToken(string token)
        {
            return _context.users.FirstOrDefault(user => user.Token == token);
        }

    }
}
