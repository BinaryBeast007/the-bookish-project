using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bookish.Controllers
{
   [EnableCors("*", "*", "*")]
    public class BuyerController : ApiController
    {
        [HttpGet]
        [Route("api/buyers")]
        public HttpResponseMessage AllBuyers()
        {
            try
            {
                var data = BuyerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/buyer/{Id}")]
        public HttpResponseMessage Buyer(int Id)
        {
            try
            {
                var data = BuyerService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/buyer/create")]
        public HttpResponseMessage CreateBuyer(BuyerDTO buyer)
        {
            try
            {
                if (buyer == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid buyer data" });
                }

                var created = BuyerService.Create(buyer);

                if (created)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Buyer created successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Failed to create buyer" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/buyer/update")]
        public HttpResponseMessage UpdateBuyer(BuyerDTO buyer)
        {
            try
            {
                if (buyer == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid buyer data" });
                }

                var created = BuyerService.Update(buyer);

                if (created)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Buyer updated successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Failed to update buyer" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/buyer/delete/{Id}")]
        public HttpResponseMessage DeleteBuyer(int Id)
        {
            try
            {
                var data = BuyerService.Delete(Id);
                var msg = "";
                if (data) msg = "Order Deleted successfully";
                else msg = "Failed to Delete Order";
                return Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
