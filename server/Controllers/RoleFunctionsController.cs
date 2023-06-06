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
    public class RoleFunctionsController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;
        public RoleFunctionsController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<RoleFunctionsResultModel>> Get()
        {
            RoleFunctionsResultModel result = new RoleFunctionsResultModel();
            try
            {
                result.RoleFunctionsData = await _dbContext.RoleFunctions.Select(r => new RoleFunctionsModel
                {
                    role_function_id = r.role_function_id,
                    name = r.name,
                    CreatedAt = r.CreatedAt
                }).ToListAsync();

                result.Result = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RoleFunctionsModel>> Get([FromRoute] int id)
        {
            try
            {
                var RoleFunctionData = await _dbContext.RoleFunctions.FirstOrDefaultAsync(r => r.role_function_id == id);
                if (RoleFunctionData != null)
                {
                    return Ok(RoleFunctionData);
                }
                else
                {
                    return BadRequest(new { message = "Chức năng không tồn tại", result = false });
                };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, result = false });
            }
        }


        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Add([FromBody] RoleFunctionRequest dataReq)
        {
            ResponseResult responseResult = new ResponseResult();
            var RoleFunctionData = new RoleFunctions
            {
                name = dataReq.name
            };
            try
            {
                await _dbContext.RoleFunctions.AddAsync(RoleFunctionData);
                await _dbContext.SaveChangesAsync();
                responseResult.Result = true;
                responseResult.Message = "Thêm dữ liệu chức năng thành công";
                return Ok(responseResult);
            }
            catch (Exception ex)
            {
                responseResult.Result = false;
                responseResult.Message = ex.Message;
                return BadRequest(responseResult);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ResponseResult>> Update([FromRoute] int id, [FromBody] RoleFunctionRequest dataReq)
        {
            ResponseResult responseResult = new ResponseResult();
            var RoleFunctionUpdate = _dbContext.RoleFunctions.FirstOrDefault(r => r.role_function_id == id);

            if (RoleFunctionUpdate != null)
            {
                RoleFunctionUpdate.name = dataReq.name;
                try
                {
                    _dbContext.Update(RoleFunctionUpdate);
                    await _dbContext.SaveChangesAsync();
                    responseResult.Result = true;
                    responseResult.Message = "Cập nhật dữ liệu chức năng thành công";
                    return Ok(responseResult);

                }
                catch (Exception ex)
                {
                    responseResult.Result = false;
                    responseResult.Message = ex.Message;
                    return BadRequest(responseResult);
                }
            }
            else
            {
                responseResult.Result = false;
                responseResult.Message = "Chức năng Không tồn tại";
                return BadRequest(responseResult);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseResult>> Delete([FromRoute] int id)
        {
            ResponseResult responseResult = new ResponseResult();
            var RoleFunctionDelete = await _dbContext.RoleFunctions.FirstOrDefaultAsync(x => x.role_function_id == id);

            var FunctionOfDetail = await _dbContext.RoleDetails.Where(r => r.role_function_id == id).ToListAsync();

            if (RoleFunctionDelete != null)
            {

                if (FunctionOfDetail.Count > 0)
                {
                    foreach (var type in FunctionOfDetail)
                    {
                        _dbContext.RoleDetails.Remove(type);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                try
                {
                    _dbContext.RoleFunctions.Remove(RoleFunctionDelete);
                    await _dbContext.SaveChangesAsync();
                    responseResult.Result = true;
                    responseResult.Message = "Xoá chức năng thành công";
                    return Ok(responseResult);

                }
                catch (Exception ex)
                {
                    responseResult.Result = false;
                    responseResult.Message = ex.Message;
                    return BadRequest(responseResult);
                }
            }
            else
            {
                responseResult.Result = false;
                responseResult.Message = "Chức năng không tồn tại";
                return BadRequest(responseResult);
            }
        }
    }
}
