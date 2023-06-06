namespace server.Models.Requests
{
    public class ChangePasswordRequest
    {
        public string? Old_Password { get; set; }
        public string? New_Password { get; set; }

    }
}
