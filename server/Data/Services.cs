using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class Services
    {
        [Key]
        public int service_id { get; set; }

        public string service_name { get; set; }

        public string icon { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}