namespace server.Models.Result
{
    public class CitiesResultModel
    {
        public bool Result { get; set; }

        public List<CitiesModel>? CitiesData { get; set; }

        public string? Message { get; set; }
    }
}