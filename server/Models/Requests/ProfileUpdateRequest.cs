namespace server.Models.Requests
{
    public class ProfileUpdateRequest
    {

        public string? last_name { get; set; }

        public string? first_name { get; set; }

        public string? contact_number { get; set; }

        public string? address { get; set; }

        public string? avatar { get; set; }
    }
}
