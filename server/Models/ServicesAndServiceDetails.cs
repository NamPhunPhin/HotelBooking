using server.Data;

namespace server.Models
{
    public class ServicesAndServiceDetails
    {
        public int service_id { get; set; }

        public string? service_name { get; set; }

        public string? icon { get; set; }

        public List<ServiceDetails>? details { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}