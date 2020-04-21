using Mara_Carona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.BLL
{
    public class ClubBLL : IClubBLL
    {
        private readonly Context.AppContextMaracarona _context;

        public ClubBLL(Context.AppContextMaracarona context)
        {
            _context = context;
        }

        public IEnumerable<Club> GetClub()
        {
            return  _context.club.ToList();
        }
    }
}
