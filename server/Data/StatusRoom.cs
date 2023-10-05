using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class StatusRoom
    {
        [Key]
        public int status_room_id { get; set; }

        public string? status_name { get; set; }
    }
}