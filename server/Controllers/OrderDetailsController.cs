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
    public class OrderDetailsController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;

        public OrderDetailsController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<OrderDetailsModel>> Get()
        {
            List<OrderDetailsModel> OrderDetailsData = await _dbContext.OrderDetails.Select(u => new OrderDetailsModel
            {
                order_details_id = u.order_details_id,
                room_id = u.room_id,
                order_id = u.order_id,
                check_in = u.check_in,
                check_out = u.check_out,
                price = u.price,
                CreatedAt = u.CreatedAt,
                children = u.children,
                adults = u.adults,
                room_quatity = u.room_quatity,
                status_room = u.status_room,
            }).ToListAsync();

            return OrderDetailsData;
        }

        [HttpGet("{id:int}")]
        public ActionResult<OrderDetailsModel> Get([FromRoute] int id)
        {
            var OrderDetailsData = _dbContext.OrderDetails.FirstOrDefault(x => x.order_details_id == id);

            if (OrderDetailsData == null)
            {
                return BadRequest("Không tìm thấy");
            }
            else
            {
                return Ok(new OrderDetailsModel
                {
                    order_details_id = OrderDetailsData.order_details_id,
                    room_id = OrderDetailsData.room_id,
                    order_id = OrderDetailsData.order_id,
                    check_in = OrderDetailsData.check_in,
                    check_out = OrderDetailsData.check_out,
                    price = OrderDetailsData.price,
                    CreatedAt = OrderDetailsData.CreatedAt,
                    children = OrderDetailsData.children,
                    adults = OrderDetailsData.adults,
                    room_quatity = OrderDetailsData.room_quatity,
                    status_room = OrderDetailsData.status_room,
                });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<ResponseResult> ChangeStatusRoom([FromRoute] int id, [FromBody] VerifyRoomRequest reqdata)
        {
            ResponseResult responseResult = new ResponseResult();
            var orderdetaildata = _dbContext.OrderDetails.FirstOrDefault(o => o.order_id == id);
            if (orderdetaildata != null)
            {
                responseResult.Result = false;
                responseResult.Message = "Đơn hàng không tồn tại";
                return BadRequest(responseResult);
            }
            else
            {
                orderdetaildata.status_room = reqdata.status_room;
                _dbContext.OrderDetails.Update(orderdetaildata);
                _dbContext.SaveChanges();

                responseResult.Result = true;
                responseResult.Message = "Thay đổi tình trạng phòng thành công";
                return Ok(responseResult);
            }
        }

        [HttpPost]
        public async Task<OrderDetailsResultModel> AddOrderDetails(OrderDetailsModel reqdata)
        {
            OrderDetailsResultModel result = new OrderDetailsResultModel();
            var OrderDetails = new OrderDetails
            {
                room_id = reqdata.room_id,
                order_id = reqdata.order_id,
                check_in = reqdata.check_in,
                check_out = reqdata.check_out,
                price = reqdata.price,
                children = reqdata.children,
                adults = reqdata.adults,
                room_quatity = reqdata.room_quatity,
                status_room = reqdata.status_room,
            };

            var resOrderDetails = await _dbContext.AddAsync(OrderDetails);
            await _dbContext.SaveChangesAsync();

            result.Data = new OrderDetailsModel()
            {
                order_details_id = resOrderDetails.Entity.order_details_id,
                room_id = resOrderDetails.Entity.room_id,
                order_id = resOrderDetails.Entity.order_id,
                check_in = resOrderDetails.Entity.check_in,
                check_out = resOrderDetails.Entity.check_out,
                price = resOrderDetails.Entity.price,
                CreatedAt = resOrderDetails.Entity.CreatedAt,
                children = resOrderDetails.Entity.children,
                adults = resOrderDetails.Entity.adults,
                room_quatity = resOrderDetails.Entity.room_quatity,
                status_room = resOrderDetails.Entity.status_room,
            };
            result.Result = true;
            result.Message = "Nhập chi tiết đơn thành công";

            return result;
        }
    }
}
