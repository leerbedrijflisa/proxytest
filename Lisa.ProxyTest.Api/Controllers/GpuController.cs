using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lisa.ProxyTest.TransferModels;
using Lisa.ProxyTest.Api.Data;
using Lisa.ProxyTest.Api.DataModels;

namespace Lisa.ProxyTest.Api.Controllers
{
    public class GpuController : ApiController
    {


        public IHttpActionResult Get()
        {
            var gpuDatas = _apiContext.GpuDatas;
            return Ok(_dataModelFactory.Create(gpuDatas));
        }

        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        private DataModelFactory _dataModelFactory = new DataModelFactory();
        private ApiContext _apiContext = new ApiContext();
    }
}
