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
    }
}
