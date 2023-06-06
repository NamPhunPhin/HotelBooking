using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class RoleDetailsModel
    {
        [Key]
        public int role_details_id { get; set; }

        [Required]
        public int role_type_id { get; set; }

        [Required]
        public int role_function_id { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
