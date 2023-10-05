using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class StatusOrder
    {
        [Key]
        public int status_id { get; set; }

        public string? status_name { get; set; }
    }
}