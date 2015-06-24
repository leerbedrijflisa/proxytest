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
    public partial class GpuController : ApiController
    {
        private DataModelFactory _dataModelFactory = new DataModelFactory();
        private ApiContext _apiContext = new ApiContext();
    }
}
