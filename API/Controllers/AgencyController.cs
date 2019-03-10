using Domain.ServiceContracts;
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

        public IHttpActionResult GetAll()
        {
            return Json(new
            {
                AgencyList = _service.GetAll()
            });
        }
    }
}
