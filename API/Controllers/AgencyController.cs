﻿using Domain.ServiceContracts;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class AgencyController : ApiController
    {
        IAgencyService _service;

        public AgencyController(IAgencyService service)
        {
            _service = service;
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Json(new
            {
                AgencyList = await Task.FromResult(_service.GetAll())
            });
        }
    }
}
