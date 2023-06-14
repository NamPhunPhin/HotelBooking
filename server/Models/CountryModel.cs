using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class CountryModel
    {
        [Key]
        public int country_id { get; set; }

        public string? name { get; set; }

        public string? image_name { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}