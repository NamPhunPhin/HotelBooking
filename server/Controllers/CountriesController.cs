using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Helpers;
using server.Models;
using server.Models.Requests;
using server.Models.Result;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;

        public CountriesController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<ContriesResultModel>> Get()
        {
            ContriesResultModel result = new ContriesResultModel();
            result.CountriesData = new List<CountryModel>();
            try
            {
                var countriesData = await _dbContext.Countries.ToListAsync();

                if (countriesData != null)
                {
                    foreach (var item in countriesData)
                    {
                        var countryItem = new CountryModel
                        {
                            country_id = item.country_id,
                            image_name = item.image_name,
                            name = item.name,
                            CreatedAt = item.CreatedAt,
                        };
                        result.Result = true;
                        result.CountriesData.Add(countryItem);
                    }
                    return Ok(result);
                }
                else
                {
                    result.Result = false;
                    result.Message = "Hiện tại không có quốc gia nào";
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
                return Ok(result);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<QuatityHotelsInTheCityModel>>> GetQuatityHotelsInTheCityById([FromRoute] int id)
        {
            var CountryData = await _dbContext.Countries.FirstOrDefaultAsync(c => c.country_id == id);

            if (CountryData != null)
            {
                var CityData = await _dbContext.Cities.Where(c => c.country_id == CountryData.country_id).ToListAsync();

                if (CityData != null)
                {
                    List<QuatityHotelsInTheCityModel> result = new List<QuatityHotelsInTheCityModel>();
                    foreach (var city in CityData)
                    {
                        var quatityHotel = _dbContext.Hotels.Count(h => h.city_id == city.city_id);

                        var dataItem = new QuatityHotelsInTheCityModel
                        {
                            city_id = city.city_id,
                            image_name = city.image_name,
                            name = city.name,
                            quatity_hotels = quatityHotel,
                            CreatedAt = city.CreatedAt
                        };

                        result.Add(dataItem);
                    }

                    return Ok(new { Result = true, Data = result });
                }
                else
                {
                    return Ok(new { Result = false, Message = "Thành phố không tồn tại" });
                }
            }
            else
            {
                return Ok(new { Result = false, Message = "Quốc gia không tồn tại" });
            }
        }

        [HttpGet("{id:int}")]//Id của quốc gia không lấy
        public async Task<ActionResult<List<QuatityHotelsInTheCountryModel>>> CountryOutSide([FromRoute] int id)
        {
            List<QuatityHotelsInTheCountryModel> result = new List<QuatityHotelsInTheCountryModel>();
            var CountryData = await _dbContext.Countries.Where(c => c.country_id != id).ToListAsync();
            foreach (var item in CountryData)
            {
                var quatityHotel = _dbContext.Hotels.Count(h => h.country_id == item.country_id);

                var data = new QuatityHotelsInTheCountryModel
                {
                    country_id = item.country_id,
                    image_name = item.image_name,
                    name = item.name,
                    quatity_hotels = quatityHotel,
                    CreatedAt = item.CreatedAt
                };

                result.Add(data);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Add([FromBody] CountryRequest dataReq)
        {
            ResponseResult result = new ResponseResult();
            var countryReq = new Countries
            {
                name = dataReq.name,
                image_name = dataReq.image_name
            };

            try
            {
                await _dbContext.Countries.AddAsync(countryReq);
                await _dbContext.SaveChangesAsync();
                result.Result = true;
                result.Message = "Thêm quốc gia thành công";
                return result;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
                return result;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ResponseResult>> Update([FromRoute] int id, [FromBody] CountryRequest dataReq)
        {
            ResponseResult result = new ResponseResult();

            var countryUpdate = await _dbContext.Countries.FirstOrDefaultAsync(c => c.country_id == id);
            if (countryUpdate != null)
            {
                if (dataReq.name != "")
                {
                    countryUpdate.name = dataReq.name;
                }

                if (dataReq.image_name != "")
                {
                    countryUpdate.image_name = dataReq.image_name;
                }
                try
                {
                    _dbContext.Countries.Update(countryUpdate);
                    await _dbContext.SaveChangesAsync();
                    result.Result = true;
                    result.Message = "Cập nhật quốc gia thành công";
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    result.Result = false;
                    result.Message = ex.Message;
                    return Ok(result);
                }
            }
            else
            {
                result.Result = false;
                result.Message = "Quốc gia không tồn tại";
                return Ok(result);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseResult>> Delete([FromRoute] int id)
        {
            ResponseResult result = new ResponseResult();

            var countryDelete = await _dbContext.Countries.FirstOrDefaultAsync(c => c.country_id == id);

            if (countryDelete != null)
            {
                try
                {
                    _dbContext.Countries.Remove(countryDelete);
                    await _dbContext.SaveChangesAsync();
                    result.Result = true;
                    result.Message = "Xoá quốc gia thành công";
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    result.Result = false;
                    result.Message = ex.Message;
                    return Ok(result);
                }
            }
            else
            {
                result.Result = false;
                result.Message = "Quốc gia không tồn tại";
                return Ok(result);
            }
        }
    }
}