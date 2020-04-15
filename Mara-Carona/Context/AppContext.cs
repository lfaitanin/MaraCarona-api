using Microsoft.EntityFrameworkCore;
using Mara_Carona.Models;
using Mara_Carona.Models.Hub;

namespace Mara_Carona.Context
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
        : base(options)
        { }
        public DbSet<Message> Message { get; set; }
        public DbSet<Club> club { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserType> usersType { get; set; }
        public DbSet<Fixture> fixture { get; set; }

    }
}
