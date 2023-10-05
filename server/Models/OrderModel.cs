using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class OrderModel
{
    [Key]
    public int order_id { get; set; }

    public List<DetailsModel>? Details { get; set; }

    public decimal? total { get; set; }

    public string? status_order { get; set; }

    public string? status_payment { get; set; }
}
