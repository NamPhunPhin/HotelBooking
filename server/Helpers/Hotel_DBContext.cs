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

        public DbSet<Services> Services { get; set; }

        public DbSet<ServiceDetails> ServiceDetails { get; set; }

        public DbSet<HotelsServices> HotelsServices { get; set; }

        public DbSet<ImagesHotel> ImagesHotel { get; set; }

        public DbSet<Rooms> Rooms { get; set; }

        public DbSet<RoomTypes> RoomTypes { get; set; }

        public DbSet<Amenities> Amenities { get; set; }

        public DbSet<ImagesRoom> ImagesRoom { get; set; }

        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        
        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<WishList> WishList { get; set; }

        public DbSet<StatusOrder> StatusOrder { get; set; }

        public DbSet<StatusPayment> StatusPayment { get; set; }

        public DbSet<StatusRoom> StatusRoom { get; set; }

        public DbSet<Assess> Assess { get; set; }
    }
}