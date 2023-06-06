using Microsoft.AspNetCore.Mvc;

namespace server.Models.Result
{
    public class ContactsResultModel
    {
        public bool Result { get; set; }

        public List<ContactsModel>? ContactsData { get; set; }

        public string? Message { get; set; }
    }
}
