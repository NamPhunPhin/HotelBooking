using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class HotelsServices
    {
        [Key]
        public int hotels_services_id { get; set; }

        public int service_id { get; set; }

        public int service_detail_id { get; set; }

        public int hotel_id { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}