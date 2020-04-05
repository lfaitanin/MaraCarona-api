using Mara_Carona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly Context.AppContext _context;

        public UserBLL(Context.AppContext context)
        {
            _context = context;
        }

        public async void createUser(User user)
        {
            var userCreated = await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<User>>> Getusers()
        {
            return _context.users.Include(club => club.Club)
                                  .Include(userType => userType.UserType)
                                  .ToList();
        }
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            return user;
        }
        
        public async Task<ActionResult<UserType>> GetTypeUser(User user)
        {
            var typeUser = await _context.usersType.FindAsync(user.UserTypeId);
            return typeUser;
        }
        
        public async Task<ActionResult<Club>> GetClub(User user)
        {
            var club = await _context.club.FindAsync(user.clubId);
            return club;
        }
        public Fixture GetNextGame(User user)
        {
            var nextMatches = _context.fixture.Where(match => match.teamhomeid == user.clubId || match.teamawayid == user.clubId).ToList();
            var currentDate = DateTime.Today;
            Dictionary<int, double> busca = new Dictionary<int, double>();
            nextMatches.ForEach(m => busca.Add(m.id, (m.date - currentDate).TotalDays));
            busca.OrderBy(b => b.Value);

            var nextMatchId = busca.FirstOrDefault(x => x.Value > 0).Key;
            var nextMatch = nextMatches.FirstOrDefault(x => x.id == nextMatchId);
            return nextMatch;
        }
       
        public bool UserExists(int id)
        {
          return  _context.users.Any(e => e.Id == id);
        }

    }
}
