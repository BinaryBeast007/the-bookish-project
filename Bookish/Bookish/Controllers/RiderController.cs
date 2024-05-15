using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bookish.Controllers
{
    public class RiderController : ApiController
    {
        [HttpGet]
        [Route("api/allriders")]
        public HttpResponseMessage Riders()
        {
            try
            {
                var data = RiderService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/rider/{Id}")]
        public HttpResponseMessage Rider(int Id)
        {
            try
            {
                var data = RiderService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/rider/create")]
        public HttpResponseMessage CreateRider(RiderDTO rider)
        {
            try
            {
                if (rider == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid rider data" });
                }

                var created = RiderService.Create(rider);

                if (created)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Rider created successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Failed to create rider" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/rider/update")]
        public HttpResponseMessage UpdateRider(RiderDTO rider)
        {
            try
            {
                if (rider == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid rider data" });
                }

                var created = RiderService.Update(rider);

                if (created)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Rider updated successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Failed to update rider" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/rider/delete/{Id}")]
        public HttpResponseMessage DeleteRider(int Id)
        {
            try
            {
                var data = RiderService.Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
