using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bookish.Controller
{
    public class AuthorController : ApiController
    {

        [HttpGet]
        [Route("api/Authors")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = AuthorService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Authors/{id}")]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                var data = AuthorService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }





        [HttpPost]
        [Route("api/Authors/create")]
        public HttpResponseMessage Create(AuthosDTO c)
        {
            try
            {
                var data = AuthorService.Add(c);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }






        [HttpDelete]
        [Route("api/Authors/delete/{id}")]
        public HttpResponseMessage Delete(int Id)
        {
            var exdata = AuthorService.Get(Id);
            if (exdata != null)
            {
                try
                {
                    var data = AuthorService.Delete(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Not Found");
            }
        }




        [HttpPut]
        [Route("api/Authors/update")]
        public HttpResponseMessage Update(AuthosDTO p)
        {
            try
            {
                var data = AuthorService.Update(p);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }




    }
}
