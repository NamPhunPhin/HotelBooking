using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HotelDetailModel>> GetHotelDetails([FromRoute] int id)
        {
            try
            {
                var hotelsData = await _dbContext.Hotels.FirstOrDefaultAsync(h => h.hotel_id == id);
                if (hotelsData != null)
                {
                    var image_name = await _dbContext.ImagesHotel.FirstOrDefaultAsync(img => img.thumbnail.Equals(true) && img.hotel_id == hotelsData.hotel_id);

                    var productWithMinPrice = await _dbContext.Rooms.Where(r => r.hotel_id == hotelsData.hotel_id && r.price == _dbContext.Rooms.Where(r => r.hotel_id == hotelsData.hotel_id).Min(r => r.price)).FirstOrDefaultAsync();

                    List<ImagesHotel> Image_Data = await _dbContext.ImagesHotel.Where(i => i.thumbnail.Equals(false) && i.hotel_id == hotelsData.hotel_id).ToListAsync();

                    var dataResult = new HotelDetailModel
                    {
                        name = hotelsData.name,
                        address = hotelsData.address,
                        city_id = hotelsData.city_id,
                        country_id = hotelsData.country_id,
                        description = hotelsData.description,
                        distance_citycenter = hotelsData.distance_citycenter,
                        hotel_id = hotelsData.hotel_id,
                        merchant_id = hotelsData.merchant_id,
                        min_price = productWithMinPrice?.price,
                        min_discount = productWithMinPrice?.discount,
                        min_price_discount = productWithMinPrice?.price_discount,
                        rating = hotelsData.rating,
                        views = hotelsData.views,
                        images = Image_Data,
                        thumbnail = image_name?.image_name,
                        CreatedAt = hotelsData.CreatedAt
                    };
                    return Ok(dataResult);
                }
                else
                {
                    return Ok(new { result = false, message = "Khách sạn không tồn tại" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { result = false, message = ex.Message });
            }
        }
    }
}