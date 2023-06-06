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
    public class ContactsController : ControllerBase
    {
        private readonly Hotel_DBContext _dbContext;
        public ContactsController(Hotel_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<ContactsResultModel> Get()
        {
            ContactsResultModel result = new ContactsResultModel();
            try
            {
                result.ContactsData = _dbContext.Contacts
        .Select(c => new ContactsModel
        {
            contact_id = c.contact_id,
            first_name = c.first_name,
            last_name = c.last_name,
            email = c.email,
            message = c.message,
            CreatedAt = c.CreatedAt

        })
        .ToList();
                result.Result = true;
                return Ok(result);

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = false;
                return BadRequest(result);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContactsModel>> Get([FromRoute] int id)
        {

            try
            {
                var ContactData = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.contact_id == id);
                if (ContactData != null)
                {
                    var contactRes = new ContactsModel
                    {
                        contact_id = ContactData.contact_id,
                        email = ContactData.email,
                        last_name = ContactData.last_name,
                        first_name = ContactData.first_name,
                        CreatedAt = ContactData.CreatedAt,
                        message = ContactData.message,
                    };
                    return Ok(contactRes);
                }
                else
                {
                    return BadRequest("Liên lạc không tồn tại");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<ResponseResult>> Add([FromBody] ContactRequest dataReq)
        {
            ResponseResult responseResult = new ResponseResult();
            var contactData = new Contacts
            {
                first_name = dataReq.first_name,
                last_name = dataReq.last_name,
                email = dataReq.email,
                message = dataReq.message,
            };

            try
            {
                await _dbContext.Contacts.AddAsync(contactData);
                await _dbContext.SaveChangesAsync();
                responseResult.Result = true;
                responseResult.Message = "Thêm dữ liệu liên lạc thành công";
                return Ok(responseResult);

            }
            catch (Exception ex)
            {
                responseResult.Result = false;
                responseResult.Message = ex.Message;
                return BadRequest(responseResult);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseResult>> delete([FromRoute] int id)
        {
            ResponseResult responseResult = new ResponseResult();
            var contactRemove = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.contact_id == id);
            if (contactRemove != null)
            {
                try
                {
                    _dbContext.Contacts.Remove(contactRemove);
                    await _dbContext.SaveChangesAsync();
                    responseResult.Result = true;
                    responseResult.Message = "Xoá dữ liệu liên lạc thành công";
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
                responseResult.Message = "Liên lạc không tồn tại";
                return BadRequest(responseResult);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ResponseResult>> update([FromRoute] int id, [FromBody] ContactRequest dataReq)
        {
            ResponseResult responseResult = new ResponseResult();
            var ContactUpdate = await _dbContext.Contacts.FirstOrDefaultAsync(c => c.contact_id == id);

            if (ContactUpdate != null)
            {
                try
                {
                    ContactUpdate.first_name = dataReq.first_name;
                    ContactUpdate.last_name = dataReq.last_name;
                    ContactUpdate.email = dataReq.email;
                    ContactUpdate.message = dataReq.message;
                    _dbContext.Update(ContactUpdate);
                    await _dbContext.SaveChangesAsync();
                    responseResult.Result = true;
                    responseResult.Message = "Cập nhật liên lạc thành công";
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
                responseResult.Message = "Liên Lạc không tồn tại";
                return BadRequest(responseResult);
            }

        }
    }
}
