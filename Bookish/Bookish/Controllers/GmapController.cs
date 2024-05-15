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
    public class GmapController : ApiController
    {
        [HttpGet]
        [Route("api/gmap/{from}/{to}")]
        public HttpResponseMessage GetGoogleMapsLink(string from, string to)
        {
            try
            {
                var url = $"https://www.google.com/maps/dir/{from}/{to}";
                var response = Request.CreateResponse(HttpStatusCode.OK, url);
                return response;
            }
            catch (Exception ex)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}
