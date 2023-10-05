namespace server.Models.Result
{
    public class OrdersResultModel
    {
        public bool Result { get; set; }

        public List<OrdersModel>? Data { get; set; }

        public string? Message { get; set; }
    }
}