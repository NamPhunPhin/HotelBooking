using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Helpers;
using server.Models;
using server.Models.Requests;
using server.Models.Result;
using System.Reflection.Metadata.Ecma335;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;

        public MerchantsController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Add([FromBody] MerchantRequest dataRes)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                var MerchantData = new Merchants
                {
                    name = dataRes.name,
                    address = dataRes.address,
                    contact_number = dataRes.contact_number,
                    email = dataRes.email,
                };

                await _dbContext.Merchants.AddAsync(MerchantData);
                await _dbContext.SaveChangesAsync();
                result.Result = true;
                result.Message = "Đăng ký trở thành đối tác thành công";
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ResponseResult>> Update([FromRoute] int id, [FromBody] MerchantRequest dataRes)
        {
            ResponseResult result = new ResponseResult();
            var merchantUpdate = _dbContext.Merchants.FirstOrDefault(m => m.merchant_id == id);
            if (merchantUpdate != null)
            {
                merchantUpdate.address = dataRes.address;
                merchantUpdate.email = dataRes.email;
                merchantUpdate.contact_number = dataRes.contact_number;
                merchantUpdate.name = dataRes.name;
                try
                {
                    _dbContext.Merchants.Update(merchantUpdate);
                    await _dbContext.SaveChangesAsync();
                    result.Result = true;
                    result.Message = "Thay đổi thông tin đối tác thành công";
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    result.Result = false;
                    result.Message = ex.Message;
                    return BadRequest(result);
                }
            }
            else
            {
                result.Result = false;
                result.Message = "Thông tin đối tác không tồn tại";
                return BadRequest(result);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseResult>> Delete([FromRoute] int id)
        {
            ResponseResult result = new ResponseResult();

            var merchantDelete = _dbContext.Merchants.FirstOrDefault(m => m.merchant_id == id);
            if (merchantDelete != null)
            {
                try
                {
                    _dbContext.Merchants.Remove(merchantDelete);
                    await _dbContext.SaveChangesAsync();
                    result.Result = true;
                    result.Message = "Xoá đối tác thành công";
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    result.Result = false;
                    result.Message = ex.Message;
                    return BadRequest(result);
                }
            }
            else
            {
                result.Result = false;
                result.Message = "Thông tin đối tác không tồn tại";
                return BadRequest(result);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<MerchantsModel>>> Get()
        {
            try
            {
                List<MerchantsModel> merchantData = _dbContext.Merchants.Select(m => new MerchantsModel
                {
                    address = m.address,
                    CreatedAt = m.CreatedAt,
                    contact_number = m.contact_number,
                    email = m.email,
                    merchant_id = m.merchant_id,
                    name = m.name
                }).ToList();
                return Ok(merchantData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}