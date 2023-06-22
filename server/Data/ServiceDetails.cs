using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class ServiceDetails
    {
        [Key]
        public int service_detail_id { get; set; }

        public int service_id { get; set; }

        public string service_detail_name { get; }

        public string icon { get; set; }

        public decimal price { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}