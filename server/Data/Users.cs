using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }

        public int? role_type_id { get; set; }

        public int? merchant_id  { get; set; }

        public string? last_name { get; set; }

        public string? first_name { get; set; }

        public string? contact_number { get; set; } = null;

        public string? address { get; set; } = null;

        public string? avatar { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        public decimal? coin { get; set; } = 0;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

    }
}
