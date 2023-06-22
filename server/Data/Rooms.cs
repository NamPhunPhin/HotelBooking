using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class Rooms
    {
        [Key]
        public int room_id { get; set; }

        public int hotel_id { get; set; }

        public int room_type_id { get; set; }

        public int number_people { get; set; }

        public int quatity { get; set; }

        public decimal price { get; set; }

        public double discount { get; set; } = 0;

        public decimal? price_discount { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}