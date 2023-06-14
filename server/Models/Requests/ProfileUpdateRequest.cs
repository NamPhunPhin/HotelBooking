namespace server.Models.Requests
{
    public class ProfileUpdateRequest
    {
        public string? last_name { get; set; } = null;

        public string? first_name { get; set; } = null;

        public string? contact_number { get; set; } = null;

        public string? address { get; set; } = null;

        public string? avatar { get; set; } = null;
    }
}