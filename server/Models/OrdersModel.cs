using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class OrdersModel
{
    [Key]
    public int order_id { get; set; }

    public string? fullname { get; set; }

    public string? contact_number { get; set; }

    public string? email { get; set; }

    public string? address { get; set; }

    public decimal? total_cost { get; set; }

    public int? status_order { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public int? used_coin { get; set; }

    public int? status_payment { get; set; }

    public int? hotel_id { get; set; }

    public int? user_id { get; set; }

    public int? extra_people { get; set; }

    public decimal? extra_price { get; set; }

}
