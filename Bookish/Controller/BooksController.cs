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
    public class BooksController : ApiController
    { 
    [HttpGet]
        [Route("api/Books")]
        public HttpResponseMessage All()
    {
        try
        {
            var data = BooksService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        catch (Exception ex)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    [HttpGet]
    [Route("api/Books/{id}")]
    public HttpResponseMessage Get(int Id)
    {
        try
        {
            var data = BooksService.Get(Id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        catch (Exception ex)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        }
    }





    [HttpPost]
    [Route("api/Books/create")]
    public HttpResponseMessage Create(BooksDTO c)
    {
        try
        {
            var data = BooksService.Add(c);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        catch (Exception ex)
        {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
        }

    }






    [HttpDelete]
    [Route("api/Books/delete/{id}")]
    public HttpResponseMessage Delete(int Id)
    {
        var exdata = BooksService.Get(Id);
        if (exdata != null)
        {
            try
            {
                var data = BooksService.Delete(Id);
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
    [Route("api/Books/update")]
    public HttpResponseMessage Update(BooksDTO p)
    {
        try
        {
            var data = BooksService.Update(p);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        catch (Exception ex)
        {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
        }

    }




}

    
}
