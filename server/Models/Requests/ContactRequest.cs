namespace server.Models.Requests
{
    public class ContactRequest
    {
        public string? last_name { get; set; }

        public string? first_name { get; set; }

        public string? email { get; set; }

        public string? message { get; set; }
    }
}
