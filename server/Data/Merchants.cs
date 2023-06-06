using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class Merchants
    {
        [Key]
        public int merchant_id { get; set; }

        public string? name { get; set; }

        public string? contact_number { get; set; }

        public string? email { get; set; }

        public string? address { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}