using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class RoleFunctions
    {
        [Key]
        public int role_function_id { get; set; }

        public string? name { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
