using Microsoft.AspNetCore.Mvc;

namespace server.Models
{
    public class AuthResultModel
    {
        public bool Result{ get; set;}

        public UsersModels? Data { get; set;}

        public string? Message { get; set; }
    }
}
