namespace server.Models.Result
{
    public class OrderResultModel
    {
        public bool Result { get; set; }

        public OrdersModel? Data { get; set; }

        public string? Message { get; set; }
    }
}