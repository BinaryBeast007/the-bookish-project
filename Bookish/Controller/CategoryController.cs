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
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/Category")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = CategoryService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Category/{id}")]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                var data = CategoryService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }





        [HttpPost]
        [Route("api/Category/create")]
        public HttpResponseMessage Create(CategoryDTO c)
        {
            try
            {
                var data = CategoryService.Add(c);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }






        [HttpDelete]
        [Route("api/Category/delete/{id}")]
        public HttpResponseMessage Delete(int Id)
        {
            var exdata = CategoryService.Get(Id);
            if (exdata != null)
            {
                try
                {
                    var data = CategoryService.Delete(Id);
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
        [Route("api/Category/update")]
        public HttpResponseMessage Update(CategoryDTO p)
        {
            try
            {
                var data = CategoryService.Update(p);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }




    }
}

