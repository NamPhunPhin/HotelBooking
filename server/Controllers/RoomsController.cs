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
    public class RoomsController : ControllerBase
    {
        public readonly Hotel_DBContext _dbContext;

        public RoomsController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<RoomsOfTheHotelModel>>> getRoomsByHotelId([FromRoute] int id)
        {
            var type_id = await _dbContext.Rooms.Where(r => r.hotel_id == id).Select(r => r.room_type_id).Distinct().ToListAsync();

            if (type_id != null)
            {
                List<RoomsOfTheHotelModel> Result = new List<RoomsOfTheHotelModel>();
                foreach (var item_type in type_id)
                {
                    List<AmenitiesModel> AmenitiesData = new List<AmenitiesModel>();
                    var RoomTypesData = await _dbContext.RoomTypes.Where(type => type.room_type_id == item_type).FirstAsync();
                    var thumbnail_type = await _dbContext.ImagesRoom.Where(img => img.room_type_id == item_type && img.thumbnail.Equals(true)).Select(img => img.image_name).FirstOrDefaultAsync();
                    var RoomsData = await _dbContext.Rooms.Where(r => r.hotel_id == id && r.room_type_id == item_type).ToListAsync();
                    var RoomAmenitiesData = await _dbContext.RoomAmenities.Where(a => a.room_type_id == item_type).ToListAsync();
                    if (RoomAmenitiesData != null)
                    {
                        foreach (var amenity in RoomAmenitiesData)
                        {
                            var AmenityRes = await _dbContext.Amenities.FirstAsync(a => a.amenity_id == amenity.amenity_id);

                            var AmenitiesItem = new AmenitiesModel
                            {
                                amenity_id = AmenityRes.amenity_id,
                                icon = AmenityRes.icon,
                                name = AmenityRes.name,
                                show = amenity.show,
                                CreatedAt = AmenityRes.CreatedAt
                            };
                            AmenitiesData.Add(AmenitiesItem);
                        }
                    }

                    var RoomsResult = new RoomsOfTheHotelModel
                    {
                        Rooms = RoomsData,
                        Amenities = AmenitiesData,
                        name = RoomTypesData.name,
                        CreatedAt = RoomTypesData.CreatedAt,
                        number_bed = RoomTypesData.number_bed,
                        room_area = RoomTypesData.room_area,
                        room_type_id = RoomTypesData.room_type_id,
                        smoking_allowed = RoomTypesData.smoking_allowed,
                        thumbnail = thumbnail_type,
                    };

                    Result.Add(RoomsResult);
                }
                return Result;
            }
            else
            {
                return Ok(new { result = false, message = "Rỗng" });
            }
        }
    }
}