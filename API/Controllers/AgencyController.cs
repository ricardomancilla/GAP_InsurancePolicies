using Domain.ServiceContracts;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class AgencyController : BaseApiController
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
