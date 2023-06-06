using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class RoleFunctionsModel
    {
        [Key]
        public int role_function_id { get; set; }

        public string? name { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
