using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;

namespace Lisa.ProxyTest.Api.Controllers
{
    public partial class GpuController
    {
        [HttpGet]
        [Route("200/gpu")]
        public IHttpActionResult GetOk()
        {
            var gpuDatas = _apiContext.GpuDatas;
            return Ok(_dataModelFactory.Create(gpuDatas));
        }

        [HttpGet]
        [Route("307/gpu")]
        public HttpResponseMessage GetTemporaryRedirect()
        {
            var response = Request.CreateResponse(HttpStatusCode.TemporaryRedirect);
            var Uri = Request.RequestUri.Authority;
            response.Headers.Location = new Uri(Uri + "/200/gpu");
            return response;
        }

        [HttpGet]
        [Route("308/gpu")]
        public HttpResponseMessage GetPermRedirect()
        {
            var response = Request.CreateResponse((HttpStatusCode)308);
            var Uri = Request.RequestUri.Authority;
            response.Headers.Location = new Uri(Uri + "/200/gpu");
            return response;
        }

        [HttpGet]
        [Route("400/gpu")]
        public IHttpActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet]
        [Route("401/gpu")]
        public IHttpActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        [HttpGet]
        [Route("403/gpu")]
        public HttpResponseMessage GetForbidden()
        {
            return this.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "This method is not allowed!");
        }

        [HttpGet]
        [Route("404/gpu")]
        public IHttpActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet]
        [Route("410/gpu")]
        public HttpResponseMessage GetGone()
        {
            return this.Request.CreateErrorResponse(HttpStatusCode.Gone, "This resourse is no longer available!");
        }

        [HttpGet]
        [Route("500/gpu")]
        public IHttpActionResult GetInternalServerError()
        {
            return InternalServerError();
        }
    }
}