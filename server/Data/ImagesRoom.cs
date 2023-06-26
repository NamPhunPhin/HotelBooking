using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class ImagesRoom
    {
        [Key]
        public int image_id { get; set; }

        public int room_type_id { get; set; }

        public string? image_name { get; set; }

        public Boolean thumbnail { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}