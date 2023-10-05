namespace server.Models.Result
{
    public class WishListResultModel
    {
        public bool Result { get; set; }

        public List<WishListModel>? Data { get; set; }

        public string? Message { get; set; }
    }
}