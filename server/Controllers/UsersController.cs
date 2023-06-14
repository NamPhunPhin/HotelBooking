using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using server.Data;
using server.Helpers;
using server.Models;
using server.Models.Requests;
using server.Models.Result;
using System.Net;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;

        public UsersController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<UsersModel>> Get()
        {
            List<UsersModel> UserData = await _dbContext.Users
        .Select(u => new UsersModel
        {
            user_id = u.user_id,
            merchant_id = u.merchant_id,
            first_name = u.first_name,
            last_name = u.last_name,
            email = u.email,
            address = u.address,
            contact_number = u.contact_number,
            coin = u.coin,
            avatar = u.avatar,
            role_type_id = u.role_type_id,
            CreatedAt = u.CreatedAt,
        })
        .ToListAsync();

            return UserData;
        }

        [HttpGet("{id:int}")]
        public ActionResult<UsersModel> Get([FromRoute] int id)
        {
            var UserData = _dbContext.Users.FirstOrDefault(x => x.user_id == id);

            if (UserData == null)
            {
                return BadRequest("Người dùng không tồn tại");
            }
            else
            {
                return Ok(new UsersModel
                {
                    user_id = UserData.user_id,
                    merchant_id = UserData.merchant_id,
                    first_name = UserData.first_name,
                    last_name = UserData.last_name,
                    email = UserData.email,
                    address = UserData.address,
                    contact_number = UserData.contact_number,
                    coin = UserData.coin,
                    avatar = UserData.avatar,
                    role_type_id = UserData.role_type_id,
                    CreatedAt = UserData.CreatedAt
                });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<ResponseResult> ChangePassword([FromRoute] int id, [FromBody] ChangePasswordRequest reqData)
        {
            ResponseResult responseResult = new ResponseResult();
            var UserData = _dbContext.Users.FirstOrDefault(u => u.user_id == id);

            if (UserData == null)
            {
                responseResult.Result = false;
                responseResult.Message = "Người dùng không tồn tại";
                return BadRequest(responseResult);
            }
            else
            {
                bool passwordMatch = BCrypt.Net.BCrypt.Verify(reqData.Old_Password, UserData.password);
                if (passwordMatch)
                {
                    string salt = BCrypt.Net.BCrypt.GenerateSalt();
                    string hashPassword = BCrypt.Net.BCrypt.HashPassword(reqData.New_Password, salt);
                    UserData.password = hashPassword;
                    _dbContext.Users.Update(UserData);
                    _dbContext.SaveChanges();

                    responseResult.Result = true;
                    responseResult.Message = "Thay đổi mật khẩu thành công";
                    return Ok(responseResult);
                }
                else
                {
                    responseResult.Result = false;
                    responseResult.Message = "Mật khẩu cũ không chính xác";
                    return Ok(responseResult);
                }
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ResponseResult> Delete([FromRoute] int id)
        {
            ResponseResult responseResult = new ResponseResult();
            var UserData = _dbContext.Users.FirstOrDefault(u => u.user_id == id);

            if (UserData == null)
            {
                responseResult.Result = false;
                responseResult.Message = "Người dùng không tồn tại";
                return BadRequest(responseResult);
            }
            else
            {
                _dbContext.Users.Remove(UserData);
                _dbContext.SaveChanges();
                responseResult.Result = true;
                responseResult.Message = "Đã xoá người dùng thành công";
                return Ok(responseResult);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<ResponseResult> UpdateProfile([FromBody] ProfileUpdateRequest dataReq, [FromRoute] int id)
        {
            ResponseResult responseResult = new ResponseResult();
            var currentUserUpdate = _dbContext.Users.FirstOrDefault(u => u.user_id == id);
            if (currentUserUpdate != null)
            {
                if (dataReq.first_name != null)
                {
                    currentUserUpdate.first_name = dataReq.first_name;
                }
                if (dataReq.last_name != null)
                {
                    currentUserUpdate.last_name = dataReq.last_name;
                }
                if (dataReq.address != null)
                {
                    currentUserUpdate.address = dataReq.address;
                }
                if (dataReq.contact_number != null)
                {
                    currentUserUpdate.contact_number = dataReq.contact_number;
                }
                if (dataReq.avatar != null)
                {
                    currentUserUpdate.avatar = dataReq.avatar;
                }

                _dbContext.Update(currentUserUpdate);
                _dbContext.SaveChanges();
                responseResult.Result = true;
                responseResult.Message = "Cập nhật thông tin cá nhân của bạn thành công";
                return responseResult;
            }
            else
            {
                responseResult.Result = false;
                responseResult.Message = "Người dùng không tồn tại";
                return responseResult;
            }
        }
    }
}