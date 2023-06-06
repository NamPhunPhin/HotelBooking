using Microsoft.AspNetCore.Mvc;

namespace server.Models.Result
{
    public class AuthResultModel
    {
        public bool Result { get; set; }

        public UsersModel? Data { get; set; }

        public string? Message { get; set; }
    }
}
