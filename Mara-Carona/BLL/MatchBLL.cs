using Mara_Carona.Interfaces.BLL;
using Mara_Carona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.BLL
{
    public class MatchBLL : IMatchBLL
    {
        private readonly Context.AppContext _context;

        public MatchBLL(Context.AppContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Match>> getMatchRiders(int matchId, int typeId)
        {
            var user = await _context.Match.Where(u => u.Id == matchId || u.UserTypeId != typeId).FirstAsync();
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public void createMatchRider(Match match)
        {
            _context.Match.Add(match);
            _context.SaveChanges();
        }
    }
}
