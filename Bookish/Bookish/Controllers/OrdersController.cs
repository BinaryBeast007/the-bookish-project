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
    public class OrdersController : ApiController
    {
        [HttpGet]
        [Route("api/orders")]
        public HttpResponseMessage AllOrders()
        {
            try
            {
                var data = OrderService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/order/{Id}")]
        public HttpResponseMessage Order(int Id)
        {
            try
            {
                var data = OrderService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/order/create")]
        public HttpResponseMessage CreateOrder(OrdersDTO order)
        {
            try
            {
                if (order == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid Order data" });
                }

                var created = OrderService.Create(order);

                if (created)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Order created successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Failed to create Order" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/order/update")]
        public HttpResponseMessage UpdateOrder(OrdersDTO order)
        {
            try
            {
                if (order == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid Order data" });
                }

                var created = OrderService.Update(order);

                if (created)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Order updated successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Failed to update Order" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/order/delete/{Id}")]
        public HttpResponseMessage DeleteOrder(int Id)
        {
            try
            {
                var data = OrderService.Delete(Id);
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
