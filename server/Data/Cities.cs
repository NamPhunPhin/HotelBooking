using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class Cities
    {
        [Key]
        public int city_id { get; set; }

        public int country_id { get; set; }

        public string? name { get; set; }

        public string? image_name { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}