using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data
{
    public class OrderDetails
    {
        [Key]
        public int order_details_id { get; set; }

        public int? room_id { get; set; }

        public int? order_id { get; set; }

        public DateTime? check_in { get; set; }

        public DateTime? check_out { get; set; }

        public decimal? price { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public int? children { get; set; }

        public int? adults { get; set; }

        public int? room_quatity { get; set; }

        public int? status_room { get; set; }

    }
}
