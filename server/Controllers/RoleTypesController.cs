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
    public class RoleTypesController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;
        public RoleTypesController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<RoleTypesResultModel>> Get()
        {
            RoleTypesResultModel result = new RoleTypesResultModel();
            try
            {
                result.RoleTypesData = await _dbContext.RoleTypes.Select(r => new RoleTypesModel
                {
                    role_type_id = r.role_type_id,
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
        public async Task<ActionResult<RoleTypesModel>> Get([FromRoute] int id)
        {
            try
            {
                var RoleTypeData = await _dbContext.RoleTypes.FirstOrDefaultAsync(r => r.role_type_id == id);
                if (RoleTypeData != null)
                {
                    return Ok(RoleTypeData);
                }
                else
                {
                    return BadRequest(new { message = "Vai trò không tồn tại", result = false });
                };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, result = false });
            }
        }


        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Add([FromBody] RoleTypeRequest dataReq)
        {
            ResponseResult responseResult = new ResponseResult();
            var RoleTypeData = new RoleTypes
            {
                name = dataReq.name
            };
            try
            {
                await _dbContext.RoleTypes.AddAsync(RoleTypeData);
                await _dbContext.SaveChangesAsync();
                responseResult.Result = true;
                responseResult.Message = "Thêm dữ liệu vai trò thành công";
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
        public async Task<ActionResult<ResponseResult>> Update([FromRoute] int id, [FromBody] RoleTypeRequest dataReq)
        {
            ResponseResult responseResult = new ResponseResult();
            var RoleTypeUpdate = _dbContext.RoleTypes.FirstOrDefault(r => r.role_type_id == id);


            if (RoleTypeUpdate != null)
            {
                RoleTypeUpdate.name = dataReq.name;
                try
                {
                    _dbContext.Update(RoleTypeUpdate);
                    await _dbContext.SaveChangesAsync();
                    responseResult.Result = true;
                    responseResult.Message = "Cập nhật vai trò thành công";
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
                responseResult.Message = "Vai trò Không tồn tại";
                return BadRequest(responseResult);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseResult>> Delete([FromRoute] int id)
        {
            ResponseResult responseResult = new ResponseResult();
            var RoleTypeDelete = await _dbContext.RoleTypes.FirstOrDefaultAsync(x => x.role_type_id == id);

            var TypeOfDetail = await _dbContext.RoleDetails.Where(r => r.role_type_id == id).ToListAsync();
            if (RoleTypeDelete != null)
            {

                if (TypeOfDetail.Count > 0)
                {
                    foreach (var type in TypeOfDetail)
                    {
                        _dbContext.RoleDetails.Remove(type);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                try
                {
                    _dbContext.RoleTypes.Remove(RoleTypeDelete);
                    await _dbContext.SaveChangesAsync();
                    responseResult.Result = true;
                    responseResult.Message = "Xoá vai trò thành công";
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
                responseResult.Message = "Vai trò không tồn tại";
                return BadRequest(responseResult);
            }
        }
    }
}
