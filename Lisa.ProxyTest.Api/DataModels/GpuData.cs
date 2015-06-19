using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lisa.ProxyTest.Api.DataModels
{
    public class GpuData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ManufacturerData Manufacturer { get; set; }
        public virtual List<MemoryData> Memories { get; set; }
        public Decimal PciVersion { get; set; }
    }
}