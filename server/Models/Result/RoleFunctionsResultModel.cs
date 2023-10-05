using Microsoft.AspNetCore.Mvc;

namespace server.Models.Result
{
    public class RoleFunctionsResultModel
    {
        public bool Result { get; set; }

        public List<RoleFunctionsModel>? RoleFunctionsData { get; set; }

        public string? Message { get; set; }
    }
}