using System.ComponentModel.DataAnnotations;

namespace server.Models.Requests
{
    public class MerchantRequest
    {
        public string? name { get; set; }

        public string? contact_number { get; set; }

        public string? email { get; set; }

        public string? address { get; set; }
    }
}