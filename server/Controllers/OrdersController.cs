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
    public class OrdersController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;

        public OrdersController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<OrdersResultModel>> GetOrders()
        {
            OrdersResultModel ordersdata = new OrdersResultModel();
            ordersdata.Data = new List<OrdersModel>();
            try
            {
                var orders = await _dbContext.Orders.ToListAsync();
                if (orders != null)
                {
                    foreach(var o in orders)
                    {
                        var orderitem = new OrdersModel
                        {
                            order_id = o.order_id,
                            fullname = o.fullname,
                            contact_number = o.contact_number,
                            email = o.email,
                            address = o.address,
                            total_cost = o.total_cost,
                            CreatedAt = o.CreatedAt,
                            used_coin = o.used_coin,
                            hotel_id = o.hotel_id,
                            user_id = o.user_id,
                            extra_people = o.extra_people,
                            extra_price = o.extra_price,
                            status_order = o.status_order,
                            status_payment = o.status_payment,
                        };

                        ordersdata.Data.Add(orderitem);
                    }

                    ordersdata.Result = true;
                }
                else
                {
                    ordersdata.Result = false;
                    ordersdata.Message = "Không tìm thấy đơn hàng nào";
                }
            }catch(Exception ex)
            {
                ordersdata.Result=false;
                ordersdata.Message = ex.Message;
            }

            return Ok(ordersdata);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrdersResultModel>> GetOrdersByUserId([FromRoute]int id)
        {
            OrdersResultModel ordersdata = new OrdersResultModel();
            ordersdata.Data = new List<OrdersModel>();
            try
            {
                var orders = await _dbContext.Orders.Where(o => o.user_id == id).ToListAsync();
                if (orders != null)
                {
                    foreach (var o in orders)
                    {
                        var ordersitem = new OrdersModel
                        {
                            order_id = o.order_id,
                            fullname = o.fullname,
                            contact_number = o.contact_number,
                            email = o.email,
                            address = o.address,
                            total_cost = o.total_cost,
                            CreatedAt = o.CreatedAt,
                            used_coin = o.used_coin,
                            hotel_id = o.hotel_id,
                            user_id = o.user_id,
                            extra_people = o.extra_people,
                            extra_price = o.extra_price,
                            status_order = o.status_order,
                            status_payment = o.status_payment,

                        };
                        ordersdata.Data.Add(ordersitem);
                    }
                    ordersdata.Result = true;
                }
                else
                {
                    ordersdata.Result = false;
                    ordersdata.Message = "Không tìm thấy đơn hàng nào của người dùng này";
                }
            }catch (Exception ex)
            {
                ordersdata.Result = false;
                ordersdata.Message = ex.Message;
            }
            return Ok(ordersdata);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<OrderModel>>> GetOrderByUserId([FromRoute]int id)
        {
            var Result = new List<OrderModel>();
                var orders = await _dbContext.Orders.Where(o => o.user_id == id).ToListAsync();
                if (orders != null)
                {
                    foreach (var o in orders)
                    {
                        var orderdata = new OrderModel();
                        orderdata.Details = new List<DetailsModel>();
                        orderdata.order_id = o.order_id;
                        orderdata.total = o.total_cost;
                        var statusorder = await _dbContext.StatusOrder.Where(s => s.status_id == o.status_order).FirstOrDefaultAsync();
                        var statuspayment = await _dbContext.StatusPayment.Where(s => s.status_payment_id == o.status_payment).FirstOrDefaultAsync();
                        orderdata.status_order = statusorder.status_name;
                        orderdata.status_payment = statuspayment.status_name;
                        var orderdetails = await _dbContext.OrderDetails.Where(od => od.order_id == o.order_id).ToListAsync();
                        foreach (var od in orderdetails)
                        {
                            var roomid = od.room_id;
                            var checkin = od.check_in;
                            var checkout = od.check_out;
                            var Childs = od.children;
                            var adults = od.adults;
                            var quantity = od.room_quatity;
                            var price = od.price;
                            var room = await _dbContext.Rooms.Where(r => r.room_id == roomid).FirstOrDefaultAsync();
                            var hotelid = await _dbContext.Hotels.Where(h => h.hotel_id == room.hotel_id).FirstOrDefaultAsync();
                            var roomtypeid = await _dbContext.RoomTypes.Where(rt => rt.room_type_id == room.room_type_id).FirstOrDefaultAsync();
                            var hotelname = hotelid.name;
                            var rate = hotelid.rating;
                            var thumbnail = await _dbContext.ImagesHotel.Where(i => i.thumbnail.Equals(true) && i.hotel_id == hotelid.hotel_id).FirstOrDefaultAsync();
                            var roomname = roomtypeid.name;
                            var statusroom = await _dbContext.StatusRoom.Where(s => s.status_room_id == od.status_room).FirstOrDefaultAsync();
                            var data = new DetailsModel
                            {
                                hotel_name = hotelname,
                                room_name = roomname,
                                rating = rate,
                                thumbnail = thumbnail.image_name,
                                check_in = checkin,
                                check_out = checkout,
                                Childrens = Childs,
                                adults = adults,
                                quatity_room = quantity,
                                price = price,
                                status_room = statusroom.status_name,
                            };
                            orderdata.Details.Add(data);
                        }
                        Result.Add(orderdata);
                    }
                }
                return Result;
        }

        [HttpPut("{id:int}")]
        public ActionResult<ResponseResult> ChangeStatusOrder([FromRoute]int id, [FromBody] VerifyOrderRequest reqdata)
        {
            ResponseResult responseResult = new ResponseResult();
            var orderdata = _dbContext.Orders.FirstOrDefault(o => o.order_id == id);
            if (orderdata != null)
            {
                responseResult.Result = false;
                responseResult.Message = "Đơn hàng không tồn tại";
                return BadRequest(responseResult);
            }
            else
            {
                orderdata.status_order = reqdata.status_order;
                _dbContext.Orders.Update(orderdata);
                _dbContext.SaveChanges();

                responseResult.Result = true;
                responseResult.Message = "Thay đổi tình trạng đơn  thành công";
                return Ok(responseResult);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<ResponseResult> ChangeStatusPayment([FromRoute] int id, [FromBody] VerifyPaymentRequest reqdata)
        {
            ResponseResult responseResult = new ResponseResult();
            var orderdata = _dbContext.Orders.FirstOrDefault(o => o.order_id == id);
            if (orderdata != null)
            {
                responseResult.Result = false;
                responseResult.Message = "Đơn hàng không tồn tại";
                return BadRequest(responseResult);
            }
            else
            {
                orderdata.status_payment = reqdata.status_payment;
                _dbContext.Orders.Update(orderdata);
                _dbContext.SaveChanges();

                responseResult.Result = true;
                responseResult.Message = "Thay đổi tình trạng thanh toán thành công";
                return Ok(responseResult);
            }
        }

        [HttpPost]
        public async Task<OrderResultModel> AddOrder(OrdersModel reqdata)
        {
            OrderResultModel result = new OrderResultModel();
            var Order = new Orders
            {
                fullname = reqdata.fullname,
                contact_number = reqdata.contact_number,
                email = reqdata.email,
                address = reqdata.address,
                total_cost = reqdata.total_cost,
                hotel_id = reqdata.hotel_id,
                user_id = reqdata.user_id,
                status_order = reqdata.status_order,
                status_payment = reqdata.status_payment,
            };

            var resOrderData = await _dbContext.AddAsync(Order);
            await _dbContext.SaveChangesAsync();

            result.Data = new OrdersModel()
            {
                order_id = resOrderData.Entity.order_id,
                fullname = resOrderData.Entity.fullname,
                contact_number = resOrderData.Entity.contact_number,
                email = resOrderData.Entity.email,
                address = resOrderData.Entity.address,
                total_cost = resOrderData.Entity.total_cost,
                status_order = resOrderData.Entity.status_order,
                CreatedAt = resOrderData.Entity.CreatedAt,
                used_coin = resOrderData.Entity.used_coin,
                status_payment = resOrderData.Entity.status_payment,
                hotel_id = resOrderData.Entity.hotel_id,
                user_id = resOrderData.Entity.user_id,
                extra_people = resOrderData.Entity.extra_people,
                extra_price = resOrderData.Entity.extra_price,
            };
            result.Result = true;
            result.Message = "Nhập đơn thành công";

            return result;
        }

    }
}
