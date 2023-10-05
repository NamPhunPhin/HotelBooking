using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class RoomTypes
    {
        [Key]
        public int room_type_id { get; set; }

        public string? name { get; set; }

        public double room_area { get; set; }

        public int number_bed { get; set; }

        public Boolean smoking_allowed { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}