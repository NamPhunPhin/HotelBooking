using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class RoomAmenities
    {
        [Key]
        public int room_amenities_id { get; set; }

        public int room_type_id { get; set; }

        public int amenity_id { get; set; }

        public Boolean show { get; set; } = false;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}