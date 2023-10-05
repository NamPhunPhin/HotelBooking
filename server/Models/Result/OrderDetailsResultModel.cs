namespace server.Models.Result
{
    public class OrderDetailsResultModel
    {
        public bool Result { get; set; }

        public OrderDetailsModel? Data { get; set; }

        public string? Message { get; set; }
    }
}