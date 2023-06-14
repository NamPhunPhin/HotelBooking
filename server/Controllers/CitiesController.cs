using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Helpers;
using server.Models;
using server.Models.Result;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;

        public CitiesController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<CitiesResultModel>> Get()
        {
            CitiesResultModel result = new CitiesResultModel();
            result.CitiesData = new List<CitiesModel>();

            try
            {
                var CitiesData = await _dbContext.Cities.ToListAsync();
                if (CitiesData != null)
                {
                    foreach (var item in CitiesData)
                    {
                        var CitiesItem = new CitiesModel
                        {
                            city_id = item.city_id,
                            image_name = item.image_name,
                            CreatedAt = item.CreatedAt,
                            name = item.name,
                        };
                        result.CitiesData.Add(CitiesItem);
                    }
                    result.Result = true;
                }
                else
                {
                    result.Result = false;
                    result.Message = "Hiện tại không có thành phố nào";
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return Ok(result);
        }
    }
}