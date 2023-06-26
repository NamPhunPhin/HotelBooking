using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models;
using System.Collections.Generic;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;

        public ServicesController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<ServicesModel>>> GetServiceByHotelId([FromRoute] int id)
        {
            var Service_ID_List = await _dbContext.HotelsServices.Where(s => s.hotel_id == id).Select(s => s.service_id).Distinct().ToListAsync();
            List<ServicesModel> Result = new List<ServicesModel>();
            if (Service_ID_List != null)
            {
                foreach (var item in Service_ID_List)
                {
                    var ServiceItem = await _dbContext.Services.FirstOrDefaultAsync(s => s.service_id == item);
                    if (ServiceItem != null)
                    {
                        var ItemService_Convert = new ServicesModel
                        {
                            service_id = ServiceItem.service_id,
                            service_name = ServiceItem.service_name,
                            icon = ServiceItem.icon,
                            CreatedAt = ServiceItem.CreatedAt,
                        };

                        Result.Add(ItemService_Convert);
                    }
                }
            }
            return Result;
        }
    }
}