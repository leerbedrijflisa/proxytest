﻿using System;
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
        [Route("500/gpu")]
        public IHttpActionResult GetInternalServerError()
        {
            return InternalServerError();
        }
    }
}