using Microsoft.EntityFrameworkCore;
using server.Data;

namespace server.Helpers
{
    public class Hotel_DBContext : DbContext
    {
        public Hotel_DBContext(DbContextOptions<Hotel_DBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Contacts> Contacts { get; set; }

        public DbSet<RoleTypes> RoleTypes { get; set; }

        public DbSet<RoleFunctions> RoleFunctions { get; set; }

        public DbSet<RoleDetails> RoleDetails { get; set; }

        public DbSet<Merchants> Merchants { get; set; }

        public DbSet<Countries> Countries { get; set; }

        public DbSet<Cities> Cities { get; set; }

        public DbSet<Hotels> Hotels { get; set; }
    }
}