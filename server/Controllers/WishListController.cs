using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
    public class WishListController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;

        public WishListController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<WishListResultModel>> GetWishlist()
        {
            WishListResultModel wishlistdata = new WishListResultModel();
            wishlistdata.Data = new List<WishListModel>();
            try
            {
                var wishlist = await _dbContext.WishList.ToListAsync();
                if (wishlist != null)
                {
                   foreach(var w in wishlist)
                    {
                        var wishlistitem = new WishListModel
                        {
                            wishlist_id = w.wishlist_id,
                            user_id = w.user_id,
                            hotel_id = w.hotel_id,
                            CreatedAt = w.CreatedAt,
                        };
                        wishlistdata.Data.Add(wishlistitem);
                    }
                    wishlistdata.Result = true;
                }
                else
                {
                    wishlistdata.Result = false;
                    wishlistdata.Message = "Không tìm thấy wishlist nào";
                }
            }
            catch (Exception ex)
            {
                wishlistdata.Result = false;
                wishlistdata.Message = ex.Message;
            }
            return Ok(wishlistdata);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<WishListResultModel>> GetWishlistByUserId([FromRoute] int id)
        {
            WishListResultModel wishlistdata = new WishListResultModel();
            wishlistdata.Data = new List<WishListModel>();

            try
            {
                var wishlist = await _dbContext.WishList.Where(w => w.user_id == id).ToListAsync();
                if (wishlist != null)
                {
                    foreach (var w in wishlist)
                    {
                        var wishlistitem = new WishListModel
                        {
                            wishlist_id = w.wishlist_id,
                            user_id = w.user_id,
                            hotel_id = w.hotel_id,
                            CreatedAt = w.CreatedAt,
                        };
                        wishlistdata.Data.Add(wishlistitem);
                    }
                    wishlistdata.Result = true;
                }
                else
                {
                    wishlistdata.Result = false;
                    wishlistdata.Message = "Không tìm thấy danh mục yêu thích của người dùng này";
                }
            }catch(Exception ex)
            {
                wishlistdata.Result=false;
                wishlistdata.Message=ex.Message;
            }

            return Ok(wishlistdata);
        }

        [HttpPost]
        public async Task<ActionResult<WishListModel>> AddWishList(WishListModel reqdata)
        {
            try
            {
                var wishlist = new WishList
                {
                    wishlist_id = reqdata.wishlist_id,
                    user_id = reqdata.user_id,
                    hotel_id = reqdata.hotel_id,
                    CreatedAt = reqdata.CreatedAt,
                };

                var resWishlistdata = await _dbContext.AddAsync(wishlist);
                await _dbContext.SaveChangesAsync();

                WishListModel result = new WishListModel
                {
                    wishlist_id = resWishlistdata.Entity.wishlist_id,
                    user_id = resWishlistdata.Entity.user_id,
                    hotel_id = resWishlistdata.Entity.hotel_id,
                    CreatedAt = resWishlistdata.Entity.CreatedAt,
                };

                return Ok(result);
            }catch(Exception ex)
            {
                return Ok(new {Results = false, Message = ex.Message});
            }
        }
    }
}
