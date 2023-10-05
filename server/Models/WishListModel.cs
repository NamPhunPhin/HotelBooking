using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class WishListModel
{
    [Key]
    public int wishlist_id { get; set; }

    public int? user_id { get; set; }

    public int? hotel_id { get; set; }

    public DateTime? CreatedAt { get; set; }

}
