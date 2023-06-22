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
            List<HotelsModel> result = new List<HotelsModel>();
            try
            {
                var hotelsData = await _dbContext.Hotels.Where(h => h.city_id == id).ToListAsync();
                if (hotelsData != null)
                {
                    foreach (var item in hotelsData)
                    {
                        var image_name = await _dbContext.ImagesHotel.FirstOrDefaultAsync(img => img.thumbnail.Equals(true) && img.hotel_id == item.hotel_id);

                        var productWithMinPrice = await _dbContext.Rooms.Where(r => r.hotel_id == item.hotel_id && r.price == _dbContext.Rooms.Where(r => r.hotel_id == item.hotel_id).Min(r => r.price)).FirstOrDefaultAsync();

                        var dataResult = new HotelsModel
                        {
                            name = item.name,
                            address = item.address,
                            city_id = item.city_id,
                            country_id = item.country_id,
                            description = item.description,
                            distance_citycenter = item.distance_citycenter,
                            hotel_id = item.hotel_id,
                            merchant_id = item.merchant_id,
                            min_price = productWithMinPrice?.price,
                            min_discount = productWithMinPrice?.discount,
                            min_price_discount = productWithMinPrice?.price_discount,
                            rating = item.rating,
                            views = item.views,
                            thumbnail = image_name?.image_name,
                            CreatedAt = item.CreatedAt
                        };
                        result.Add(dataResult);
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new { result = false, message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<HotelsModel>>> GetHotelsByCountryId([FromRoute] int id)
        {
            List<HotelsModel> result = new List<HotelsModel>();
            try
            {
                var hotelsData = await _dbContext.Hotels.Where(h => h.country_id == id).ToListAsync();
                if (hotelsData != null)
                {
                    foreach (var item in hotelsData)
                    {
                        var image_name = await _dbContext.ImagesHotel.FirstOrDefaultAsync(img => img.thumbnail.Equals(true) && img.hotel_id == item.hotel_id);

                        var productWithMinPrice = await _dbContext.Rooms.Where(r => r.hotel_id == item.hotel_id && r.price == _dbContext.Rooms.Where(r => r.hotel_id == item.hotel_id).Min(r => r.price)).FirstOrDefaultAsync();

                        var dataResult = new HotelsModel
                        {
                            name = item.name,
                            address = item.address,
                            city_id = item.city_id,
                            country_id = item.country_id,
                            description = item.description,
                            distance_citycenter = item.distance_citycenter,
                            hotel_id = item.hotel_id,
                            merchant_id = item.merchant_id,
                            min_price = productWithMinPrice?.price,
                            min_discount = productWithMinPrice?.discount,
                            min_price_discount = productWithMinPrice?.price_discount,
                            rating = item.rating,
                            views = item.views,
                            thumbnail = image_name?.image_name,
                            CreatedAt = item.CreatedAt
                        };
                        result.Add(dataResult);
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new { result = false, message = ex.Message });
            }
        }
    }
}