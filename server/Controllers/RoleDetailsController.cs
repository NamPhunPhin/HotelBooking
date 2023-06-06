using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using server.Data;
using server.Helpers;
using server.Models;
using server.Models.Requests;
using server.Models.Result;
using System.Linq;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleDetailsController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;

        public RoleDetailsController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Add([FromBody] RoleDetailRequest dataReq)
        {
            ResponseResult result = new ResponseResult();

            var FunctionDataExits = await _dbContext.RoleDetails.FirstOrDefaultAsync(r => r.role_type_id == dataReq.role_type_id && r.role_function_id == dataReq.role_function_id);

            if (FunctionDataExits == null)
            {
                var TypeData = await _dbContext.RoleTypes.FirstOrDefaultAsync(r => r.role_type_id == dataReq.role_type_id);

                if (TypeData != null)
                {
                    var FunctionData = await _dbContext.RoleFunctions.FirstOrDefaultAsync(r => r.role_function_id == dataReq.role_function_id);
                    if (FunctionData != null)
                    {
                        var DetailData = new RoleDetails
                        {
                            role_function_id = FunctionData.role_function_id,
                            role_type_id = TypeData.role_type_id
                        };

                        await _dbContext.RoleDetails.AddAsync(DetailData);
                        await _dbContext.SaveChangesAsync();
                        result.Result = true;
                        result.Message = "Thêm chức năng của vai trò thành công";
                        return Ok(result);
                    }
                    else
                    {
                        result.Result = false;
                        result.Message = "Chức năng này không tồn tại";
                        return BadRequest(result);
                    }
                }
                else
                {
                    result.Result = false;
                    result.Message = "Vai trò này không tồn tại";
                    return BadRequest(result);
                }
            }
            else
            {
                result.Result = false;
                result.Message = "Chức năng của vai trò này đã tồn tại";
                return BadRequest(result);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RoleTypeFunctionResultModel>> GetByRoleTypeId([FromRoute] int id)
        {
            RoleTypeFunctionResultModel result = new RoleTypeFunctionResultModel();

            List<RoleDetails> RoleDetailsData = await _dbContext.RoleDetails.Where(r => r.role_type_id == id).ToListAsync();

            if (RoleDetailsData.Count > 0)
            {
                try
                {
                    result.RoleTypes = await _dbContext.RoleTypes.FirstAsync(r => r.role_type_id == id);
                    result.RoleFunctions = new List<RoleFunctions>();
                    foreach (var item in RoleDetailsData)
                    {
                        var FunctionItem = await _dbContext.RoleFunctions.FirstAsync(r => r.role_function_id == item.role_function_id);
                        result.RoleFunctions.Add(FunctionItem);
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Chức năng của vai trò không tồn tại");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ResponseResult>> Update([FromBody] RoleDetailRequest dataReq, [FromRoute] int id)
        {
            ResponseResult result = new ResponseResult();

            var Role_Function_Check = await _dbContext.RoleFunctions.FirstOrDefaultAsync(r => r.role_function_id == dataReq.role_function_id);

            var Role_Type_Check = await _dbContext.RoleTypes.FirstOrDefaultAsync(r => r.role_type_id == dataReq.role_type_id);

            var RoleDetailsUpdate = await _dbContext.RoleDetails.FirstOrDefaultAsync(r => r.role_details_id == id);

            if (RoleDetailsUpdate != null)
            {
                if (Role_Type_Check != null)
                {
                    if (Role_Function_Check != null)
                    {
                        RoleDetailsUpdate.role_function_id = dataReq.role_function_id;
                        RoleDetailsUpdate.role_type_id = dataReq.role_type_id;

                        try
                        {
                            _dbContext.RoleDetails.Update(RoleDetailsUpdate);
                            await _dbContext.SaveChangesAsync();
                            result.Result = true;
                            result.Message = "Cập nhật chức năng của vai trò thành công";
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
                        result.Message = "Chức năng không tồn tại";
                        return BadRequest(result);
                    }
                }
                else
                {
                    result.Result = false;
                    result.Message = "Vai trò không tồn tại";
                    return BadRequest(result);
                }
            }
            else
            {
                result.Result = false;
                result.Message = "Chức năng của vai trò không tồn tại";
                return BadRequest(result);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseResult>> delete([FromRoute] int id)
        {
            ResponseResult result = new ResponseResult();
            var DetailDelete = await _dbContext.RoleDetails.FirstOrDefaultAsync(r => r.role_details_id == id);
            try
            {
                if (DetailDelete != null)
                {
                    _dbContext.RoleDetails.Remove(DetailDelete);
                    await _dbContext.SaveChangesAsync();
                    result.Result = true;
                    result.Message = "Cập nhật chức năng của vai trò thành công";
                    return Ok(result);
                }
                else
                {
                    result.Result = false;
                    result.Message = "Chức năng của vai trò không tồn tại";
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
                return BadRequest(result);
            }
        }
    }
}