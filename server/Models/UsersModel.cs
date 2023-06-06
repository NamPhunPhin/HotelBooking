using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class UsersModel
{
    [Key]
    public int user_id { get; set; }

    public int? role_type_id { get; set; }

    public int? merchant_id  { get; set; }

    public string? last_name { get; set; }

    public string? first_name { get; set; }

    public string? contact_number { get; set; }

    public string? avatar { get; set; }

    public string? address { get; set; }

    public string? email { get; set; }

    public decimal? coin { get; set; }

    public DateTime? CreatedAt { get; set; }

}
