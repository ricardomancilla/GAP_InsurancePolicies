using Domain.ServiceContracts;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class CityController : BaseApiController
    {
        ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Result(await Task.FromResult(_service.GetAll()));
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Result(await Task.FromResult(_service.Find(id)));
        }
    }
}
