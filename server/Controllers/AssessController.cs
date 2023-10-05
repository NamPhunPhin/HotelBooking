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
    public class AssessController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;

        public AssessController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<AssessModel>>> GetCommentsByHotelId([FromRoute]int id)
        {
            var result = new List<AssessModel>();
            try
            {
                var comments = await _dbContext.Assess.Where(c => c.hotel_id == id).ToListAsync();
                if (comments != null)
                {
                    foreach (var comment in comments)
                    {
                        var commentitem = new AssessModel
                        {
                            assess_id = comment.assess_id,
                            user_id = comment.user_id,
                            hotel_id = comment.hotel_id,
                            rate = comment.rate,
                            comment = comment.comment,
                            CreatedAt = comment.CreatedAt,
                        };
                        result.Add(commentitem);
                    }
                    return result;
                }
                else
                {
                    return Ok(new { result = true, Message = "Không tìm thấy bình nào về khách sạn này" });
                }
            }catch(Exception ex)
            {
                return BadRequest(new {result = false, Message = ex.Message});
            }
        }

        [HttpPost]
        public async Task<AssessResultModel> AddComment(AssessModel reqdata)
        {
            AssessResultModel result = new AssessResultModel();
            var Comment = new Assess
            {
                user_id = reqdata.user_id,
                hotel_id = reqdata.hotel_id,
                rate = reqdata.rate,
                comment = reqdata.comment,
            };

            var resAssessData = await _dbContext.AddAsync(Comment);
            await _dbContext.SaveChangesAsync();

            result.Data = new AssessModel()
            {
                assess_id = resAssessData.Entity.assess_id,
                user_id = resAssessData.Entity.user_id,
                hotel_id = resAssessData.Entity.hotel_id,
                rate = resAssessData.Entity.rate,
                comment = resAssessData.Entity.comment,
                CreatedAt = resAssessData.Entity.CreatedAt,
            };
            result.Result = true;
            result.Message = "Nhập bình luận thành công";

            return result;
        }
    }
}