using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Lisa.ProxyTest.Api.DataModels;

namespace Lisa.ProxyTest.Api.Data
{
    public class ApiContext:IdentityDbContext
    {
        public ApiContext() : base("ApiContext") 
        { 
        }

        public DbSet<GpuData> GpuDatas { get; set; }
        public DbSet<ManufacturerData> ManufacturerDatas { get; set; }
        public DbSet<MemoryData> MemoryDatas { get; set; }
    }
}