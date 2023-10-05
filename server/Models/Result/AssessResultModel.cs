namespace server.Models.Result
{
    public class AssessResultModel
    {
        public bool Result { get; set; }

        public AssessModel? Data { get; set; }

        public string? Message { get; set; }
    }
}