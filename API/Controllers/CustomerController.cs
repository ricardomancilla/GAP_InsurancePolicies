using Domain.ServiceContracts;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class CustomerController : BaseApiController
    {
        ICustomerService _service;

        public CustomerController(ICustomerService service)
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

        [ActionName("GetBy")]
        public async Task<IHttpActionResult> GetBy(string filter)
        {
            return Result(await Task.FromResult(_service.FindBy(x => x.Identification.Contains(filter)
                || x.FirstName.Contains(filter) || x.LastName.Contains(filter))));
        }
    }
}
