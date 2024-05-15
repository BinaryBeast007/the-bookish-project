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
    public class ReviewsController : ApiController
    {
        [HttpGet]
        [Route("api/allreviews")]
        public HttpResponseMessage AllReviews()
        {
            try
            {
                var data = ReviewsService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/review/{Id}")]
        public HttpResponseMessage Review(int Id)
        {
            try
            {
                var data = ReviewsService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/review/create")]
        public HttpResponseMessage CreateReview(ReviewsDTO review)
        {
            try
            {
                if (review == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid Review data" });
                }

                var created = ReviewsService.Create(review);

                if (created)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Review created successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Failed to create Review" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/review/update")]
        public HttpResponseMessage UpdateReview(ReviewsDTO review)
        {
            try
            {
                if (review == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid Review data" });
                }

                var created = ReviewsService.Update(review);

                if (created)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Review updated successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Failed to update Review" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/review/delete/{Id}")]
        public HttpResponseMessage DeleteReview(int Id)
        {
            try
            {
                var data = ReviewsService.Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
