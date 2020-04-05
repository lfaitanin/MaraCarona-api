using Microsoft.EntityFrameworkCore;
using Mara_Carona.Models;

namespace Mara_Carona.Context
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
        : base(options)
        { }
        public DbSet<Club> club { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserType> usersType { get; set; }



    }
}
