using Lisa.ProxyTest.TransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lisa.ProxyTest.Api.DataModels
{
    public class DataModelFactory
    {
        public IEnumerable<Gpu> Create(IEnumerable<GpuData> gpuDatas)
        {
            var gpus = new List<Gpu>(); 

            foreach(var gpuData in gpuDatas)
            {
                gpus.Add(Create(gpuData));
            }

            return gpus;
        }

        public Gpu Create(GpuData gpuData)
        {
            return new Gpu 
            {
                Id = gpuData.Id,
                Manufacturer = Create(gpuData.Manufacturer),
                Memories = Create(gpuData.Memories),
                Name = gpuData.Name,
                PciVersion = gpuData.PciVersion
            };
        }

        public Manufacturer Create(ManufacturerData manufacturerData)
        {
            return new Manufacturer
            {
                Address = manufacturerData.Address,
                Country = manufacturerData.Country,
                Name = manufacturerData.Name
            };
        }

        public IEnumerable<Memory> Create(IEnumerable<MemoryData> memoryDatas)
        {
            var memory = new List<Memory>(); 

            foreach(var memoryData in memoryDatas)
            {
                memory.Add(Create(memoryData));
            }

            return memory;
        }

        public Memory Create(MemoryData memoryData)
        {
            return new Memory
            {
                Size = memoryData.Size
            };
        }
    }
}