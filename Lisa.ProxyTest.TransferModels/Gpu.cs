using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lisa.ProxyTest.TransferModels
{
    public class Gpu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public IEnumerable<Memory> Memories { get; set; }
        public Decimal PciVersion { get; set; }
    }
}