using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Helpers;
using server.Models;
using server.Models.Requests;
using server.Models.Result;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;
        public AuthController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<AuthResultModel> SignUp(SignUpRequest reqData)
        {
            AuthResultModel result = new AuthResultModel();
            var User_Exists = _dbContext.Users.Where(x => x.email == reqData.email).FirstOrDefault();
            if (User_Exists != null)
            {
                result.Result = false;
                result.Message = "Email đã được sử dụng";
                return result;
            }
            else
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt();

                // Hash the password with bcrypt
                string hash = BCrypt.Net.BCrypt.HashPassword(reqData.password, salt);

                var user = new Users
                {
                    first_name = reqData.first_name,
                    last_name = reqData.last_name,
                    email = reqData.email,
                    password = hash,
                };


                var resUserData = await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();



                result.Data = new UsersModel()
                {
                    user_id = resUserData.Entity.user_id,
                    first_name = resUserData.Entity.first_name,
                    last_name = resUserData.Entity.last_name,
                    email = resUserData.Entity.email,
                    contact_number = resUserData.Entity.contact_number,
                    address = resUserData.Entity.address,
                    coin = resUserData.Entity.coin,
                    avatar = resUserData.Entity.avatar,
                    merchant_id = resUserData.Entity.merchant_id,
                    role_type_id = resUserData.Entity.role_type_id,
                    CreatedAt = resUserData.Entity.CreatedAt
                };
                result.Result = true;
                result.Message = "Đăng ký thành công";

                return result;
            }

        }

        [HttpPost]
        public AuthResultModel LogIn(LogInRequest reqData)
        {
            AuthResultModel result = new AuthResultModel();
            var UserData = _dbContext.Users.FirstOrDefault(x => x.email == reqData.email);
            if (UserData == null)
            {
                result.Result = false;
                result.Message = "Tài khoản Email không tồn tại";
                return result;
            }
            else
            {
                bool passwordMatch = BCrypt.Net.BCrypt.Verify(reqData.password, UserData.password);
                if (passwordMatch)
                {
                    result.Data = new UsersModel()
                    {
                        user_id = UserData.user_id,
                        first_name = UserData.first_name,
                        last_name = UserData.last_name,
                        email = UserData.email,
                        contact_number = UserData.contact_number,
                        address = UserData.address,
                        coin = UserData.coin,
                        avatar = UserData.avatar,
                        merchant_id = UserData.merchant_id,
                        role_type_id = UserData.role_type_id,
                        CreatedAt = UserData.CreatedAt
                    };
                    result.Result = true;
                    result.Message = "Đăng nhập thành công";
                    return result;
                }
                else
                {
                    result.Result = false;
                    result.Message = "Mật khẩu sai";
                    return result;
                }
            }
        }
    }
}
