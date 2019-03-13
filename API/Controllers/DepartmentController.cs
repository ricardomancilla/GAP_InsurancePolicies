using Domain.ServiceContracts;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class DepartmentController : BaseApiController
    {
        IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
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
