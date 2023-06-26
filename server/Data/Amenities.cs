using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class Amenities
    {
        [Key]
        public int amenity_id { get; set; }

        public string name { get; set; }

        public string icon { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}