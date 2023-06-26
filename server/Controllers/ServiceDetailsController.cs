using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceDetailsController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;

        public ServiceDetailsController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<ServiceDetailsModel>>> GetServiceDetailsByHotelId([FromRoute] int id)
        {
            List<ServiceDetailsModel> Results = new List<ServiceDetailsModel>();
            var Details_ID_List = await _dbContext.HotelsServices.Where(s => s.hotel_id == id).Select(s => s.service_detail_id).Distinct().ToListAsync();

            if (Details_ID_List != null)
            {
                foreach (var item in Details_ID_List)
                {
                    var ServiceDetailItem = await _dbContext.ServiceDetails.FirstOrDefaultAsync(s => s.service_detail_id == item);
                    if (ServiceDetailItem != null)
                    {
                        var ItemService_Convert = new ServiceDetailsModel
                        {
                            service_detail_id = ServiceDetailItem.service_detail_id,
                            service_detail_name = ServiceDetailItem.service_detail_name,
                            price = ServiceDetailItem.price,
                            service_id = ServiceDetailItem.service_id,
                            icon = ServiceDetailItem.icon,
                            CreatedAt = ServiceDetailItem.CreatedAt,
                        };

                        Results.Add(ItemService_Convert);
                    }
                }
            }
            return Results;
        }
    }
}