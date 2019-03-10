using Domain.ServiceContracts;
using System.Web.Http;

namespace API.Controllers
{
    public class CityController : ApiController
    {
        ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        [ActionName("Get")]
        public IHttpActionResult GetAll()
        {
            return Json(new
            {
                CityList = _service.GetAll()
            });
        }

        [ActionName("Get")]
        public IHttpActionResult Get(int id)
        {
            return Json(_service.Find(x => x.CityID.Equals(id)));
        }
    }
}
