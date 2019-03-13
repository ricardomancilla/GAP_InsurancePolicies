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
            return Result(await Task.FromResult(_service.GetAll()));
        }
    }
}
