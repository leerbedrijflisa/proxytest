using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}