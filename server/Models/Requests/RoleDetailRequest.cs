using System.ComponentModel.DataAnnotations;

namespace server.Models.Requests
{
    public class RoleDetailRequest
    {
        [Required]
        public int role_type_id { get; set; }

        [Required]
        public int role_function_id { get; set; }

    }
}
