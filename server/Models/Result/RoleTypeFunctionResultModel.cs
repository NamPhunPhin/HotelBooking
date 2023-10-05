using server.Data;
using System.ComponentModel.DataAnnotations;

namespace server.Models.Result
{
    public class RoleTypeFunctionResultModel
    {
        [Key]
        public int role_details_id { get; set; }
        public RoleTypes? RoleTypes { get; set; }
        public List<RoleFunctions>? RoleFunctions { get; set; }
    }
}
