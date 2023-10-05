using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data
{
    public class WishList
    {
        [Key]
        public int wishlist_id { get; set; }

        public int? user_id { get; set; }

        public int? hotel_id  { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

    }
}
