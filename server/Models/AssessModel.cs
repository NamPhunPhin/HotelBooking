using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class AssessModel
{
    [Key]
    public int assess_id { get; set; }

    public int? user_id { get; set; }

    public int? hotel_id { get; set; }

    public decimal? rate { get; set; }

    public string? comment { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

}
