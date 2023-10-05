using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class StatusPayment
    {
        [Key]
        public int status_payment_id { get; set; }

        public string? status_name { get; set; }
    }
}