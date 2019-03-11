﻿using Domain.ServiceContracts;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [Authorize]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CityController : ApiController
    {
        ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Json(new
            {
                CityList = await Task.FromResult(_service.GetAll())
            });
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var city = await Task.FromResult(_service.Find(id));

            if (city == null)
                NotFound();

            return Json(city);
        }
    }
}
