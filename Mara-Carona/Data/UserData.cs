using Mara_Carona.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.Data
{
    public class UserData
    {
        private readonly Context.AppContext _context;

        public UserData(Context.AppContext context)
        {
            _context = context;
        }

        public async void Add(User user)
        {
            var usuario = await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
