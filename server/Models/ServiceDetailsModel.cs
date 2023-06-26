namespace server.Models
{
    public class ServiceDetailsModel
    {
        public int service_detail_id { get; set; }

        public int service_id { get; set; }

        public string? service_detail_name { get; set; }

        public string? icon { get; set; }

        public decimal price { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}