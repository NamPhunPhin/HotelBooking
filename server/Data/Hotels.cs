using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class Hotels
    {
        [Key]
        public int hotel_id { get; set; }

        public int merchant_id { get; set; }

        public int country_id { get; set; }

        public int city_id { get; set; }

        public string? name { get; set; }

        public string? address { get; set; }

        public string? description { get; set; }

        public decimal rating { get; set; }

        public decimal distance_citycenter { get; set; }

        public int views { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}