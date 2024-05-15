using Bookish.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Bookish.Controllers
{
    public class OpenLibraryController : ApiController
    {
        [HttpGet]
        [Route("api/openlib/search/{title}")]
        public async Task<HttpResponseMessage> Search(string title)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = $"https://openlibrary.org/search.json?q={title}";
                    var response = await httpClient.GetStringAsync(url);
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/openlib/author/{name}")]
        public async Task<HttpResponseMessage> SearchAuthor(string name)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = $"https://openlibrary.org/search.json?author={name}";
                    var response = await httpClient.GetStringAsync(url);
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
