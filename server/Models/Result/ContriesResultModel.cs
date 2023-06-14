namespace server.Models.Result
{
    public class ContriesResultModel
    {
        public bool Result { get; set; }

        public List<CountryModel>? CountriesData { get; set; }

        public string? Message { get; set; }
    }
}