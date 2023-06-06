using Microsoft.AspNetCore.Mvc;

namespace server.Models.Result
{
    public class RoleTypesResultModel
    {
        public bool Result { get; set; }

        public List<RoleTypesModel>? RoleTypesData { get; set; }

        public string? Message { get; set; }
    }
}
