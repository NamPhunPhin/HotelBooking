using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class DetailsModel
{
    [Key]
    public string? hotel_name { get; set; }

    public string? room_name { get; set; }

    public decimal rating { get; set; }

    public string? thumbnail { get; set; }

    public DateTime? check_in { get; set; }

    public DateTime? check_out { get; set; }

    public int? Childrens { get; set; }

    public int? adults { get; set; }

    public int? quatity_room { get; set; }

    public decimal? price { get; set; }

    public string? status_room { get; set; }

}
