using Domain.ServiceContracts;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class DepartmentController : ApiController
    {
        IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;

        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Json(new
            {
                DepartmentList = await Task.FromResult(_service.GetAll())
            });
        }
    }
}
