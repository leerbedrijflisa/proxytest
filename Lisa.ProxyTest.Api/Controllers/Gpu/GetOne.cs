using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Lisa.ProxyTest.Api.Controllers
{
    public partial class GpuController
    {
        [HttpGet]
        [Route("200/gpu/{id}")]
        public IHttpActionResult GetOk(int id)
        {
            var gpuData = _apiContext.GpuDatas.Find(id);
            if (gpuData == null)
            {
                return NotFound();
            }
            return Ok(_dataModelFactory.Create(gpuData));
        }

        [HttpGet]
        [Route("307/gpu/{id}")]
        public HttpResponseMessage GetTemporaryRedirect(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.TemporaryRedirect);
            var Uri = Request.RequestUri.Authority;
            response.Headers.Location = new Uri(Uri + "/200/gpu/" + id);
            return response;
        }

        [HttpGet]
        [Route("308/gpu/{id}")]
        public HttpResponseMessage GetPermRedirect(int id)
        {
            var response = Request.CreateResponse((HttpStatusCode)308);
            var Uri = Request.RequestUri.Authority;
            response.Headers.Location = new Uri(Uri + "/200/gpu/" + id);
            return response;
        }

        [HttpGet]
        [Route("400/gpu/{id}")]
        public IHttpActionResult GetBadRequest(int id)
        {
            return BadRequest();
        }

        [HttpGet]
        [Route("401/gpu/{id}")]
        public IHttpActionResult GetUnauthorized(int id)
        {
            return Unauthorized();
        }

        [HttpGet]
        [Route("403/gpu/{id}")]
        public HttpResponseMessage GetForbidden(int id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "This method is not allowed!");
        }

        [HttpGet]
        [Route("404/gpu/{id}")]
        public IHttpActionResult GetNotFound(int id)
        {
            return NotFound();
        }

        [HttpGet]
        [Route("410/gpu/{id}")]
        public HttpResponseMessage GetGone(int id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.Gone, "This resourse is no longer available!");
        }

        [HttpGet]
        [Route("500/gpu/{id}")]
        public IHttpActionResult GetInternalServerError(int id)
        {
            return InternalServerError();
        }
    }
}