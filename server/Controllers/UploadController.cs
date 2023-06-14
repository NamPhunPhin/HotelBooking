using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Models.Result;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public ActionResult<ResponseResult> Upload(IFormFile file)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                // getting file original name
                string FileName = file.FileName;

                // combining GUID to create unique name before saving in wwwroot
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;

                // getting full path inside wwwroot/images
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", FileName);
                var exists = System.IO.File.Exists(imagePath);
                if (exists)
                {
                    result.Result = false;
                    result.Message = "Đã tồn tại";
                    return result;
                }
                else
                {
                    // copying file
                    file.CopyTo(new FileStream(imagePath, FileMode.Create));

                    result.Result = true;
                    result.Message = "Tải lên thành công";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
                return result;
            }
        }
    }
}