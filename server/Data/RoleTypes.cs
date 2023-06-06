using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class RoleTypes
    {
        [Key]
        public int role_type_id { get; set; }

        public string? name { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
