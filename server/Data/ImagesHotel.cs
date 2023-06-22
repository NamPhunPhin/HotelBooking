using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data
{
    public class ImagesHotel
    {
        [Key]
        public int image_id { get; set; }

        public int hotel_id { get; set; }

        public string? image_name { get; set; }

        public Boolean thumbnail { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}