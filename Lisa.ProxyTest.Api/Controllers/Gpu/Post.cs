using Lisa.ProxyTest.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Net.Http;

namespace Lisa.ProxyTest.Api.Controllers
{
    public partial class GpuController
    {
        [HttpPost]
        [Route("200/gpu")]
        public IHttpActionResult GetOk(GpuData gpu)
        {
            //You might have a case where you post a duplicate and the server returns the resource that already exists, 
            //e.g. you have a list of countries and you try to add a country, but the country already exists. 
            //You still want to get the resource back like you do with a 201 Created.
            //This test code has a check if the resource requested actually exist. Because the 200 here is faked.

            var gpuData = _apiContext.GpuDatas.Find(gpu.Id);
            if (gpuData == null)
            {
                return NotFound();
            }
            return Ok(_dataModelFactory.Create(gpuData));
        }

        [HttpPost]
        [Route("201/gpu")]
        public IHttpActionResult GetCreated(GpuData gpu)
        {
            var Uri = Request.RequestUri.Authority;

            var savedMemory = _apiContext.MemoryDatas.Find(gpu.Memories);

            _apiContext.ManufacturerDatas.Add(new ManufacturerData
            {
                Address = gpu.Manufacturer.Address,
                Name = gpu.Manufacturer.Name,
                Country = gpu.Manufacturer.Country
            });

            _apiContext.GpuDatas.Add(new GpuData
            {
                Id = gpu.Id,
                Name = gpu.Name,
                PciVersion = gpu.PciVersion
            });

            foreach (var memory in gpu.Memories)
            {
                _apiContext.MemoryDatas.Add(new MemoryData
                {
                    Size = memory.Size
                });
            }

            _apiContext.SaveChanges();

            return Created(Uri, gpu);
        }

        [HttpPost]
        [Route("202/gpu")]
        public HttpResponseMessage GetAccepted(GpuData gpu)
        {
            return Request.CreateErrorResponse(HttpStatusCode.Accepted, "");
        }
    }
}