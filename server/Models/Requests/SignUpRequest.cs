namespace server.Models.Requests
{
    public class SignUpRequest
    {
        public string? last_name { get; set; }

        public string? first_name { get; set; }

        public string? email { get; set; }

        public string? password { get; set; }

    }
}
