using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class ContactsModel
    {
        [Key]
        public int contact_id { get; set; }

        public string? last_name { get; set; }

        public string? first_name { get; set; }

        public string? email { get; set; }

        public string? message { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

    }
}
