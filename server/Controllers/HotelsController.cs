using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        public readonly Hotel_DBContext _dbContext;

        public HotelsController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<HotelsModel>>> GetHotelsByCityId([FromRoute] int id)
        {
            try
            {
                var hotelsData = await _dbContext.Hotels.Where(h => h.city_id == id).Select(h => new HotelsModel
                {
                    name = h.name,
                    address = h.address,
                    city_id = h.city_id,
                    country_id = h.country_id,
                    description = h.description,
                    distance_citycenter = h.distance_citycenter,
                    hotel_id = h.hotel_id,
                    merchant_id = h.merchant_id,
                    rating = h.rating,
                    views = h.views,
                    CreatedAt = h.CreatedAt
                }).ToListAsync();
                return Ok(hotelsData);
            }
            catch (Exception ex)
            {
                return Ok(new { result = false, message = ex.Message });
            }
        }
    }
}