using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Lisa.ProxyTest.Api.Controllers
{
    public partial class GpuController
    {
        [HttpPost]
        [Route("200/gpu/{id}")]
        public IHttpActionResult GetOk(int id)
        {
            //You might have a case where you post a duplicate and the server returns the resource that already exists, 
            //e.g. you have a list of countries and you try to add a country, but the country already exists. 
            //You still want to get the resource back like you do with a 201 Created.
            //This test code had a check if the resource requested actually exist. Because the 200 here is faked.

            var gpuData = _apiContext.GpuDatas.Find(id);
            if (gpuData == null)
            {
                return NotFound();
            }
            return Ok(_dataModelFactory.Create(gpuData));
        }
    }
}