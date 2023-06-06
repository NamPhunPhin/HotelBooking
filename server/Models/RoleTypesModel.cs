using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class RoleTypesModel
    {
        [Key]
        public int role_type_id { get; set; }

        public string? name { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
