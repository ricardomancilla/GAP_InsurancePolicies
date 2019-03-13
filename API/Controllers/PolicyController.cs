using Domain.EntityModel;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class PolicyController : BaseApiController
    {
        IPolicyService _service;

        public PolicyController(IPolicyService service)
        {
            _service = service;
        }

        [ActionName("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Result(await Task.FromResult(_service.GetAll()));
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> Get()
        {
            return Result(await Task.FromResult(_service.FindBy(x => x.DeleteDate.Equals(null))));
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Result(await Task.FromResult(_service.Find(id)));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(PolicyModel entity)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder modelErrors = GetModelErrors(ModelState);
                var result = new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = modelErrors.ToString() };
                return Result(result);
            }

            return Result(await Task.FromResult(_service.Create(entity)));

        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(PolicyModel entity)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder modelErrors = GetModelErrors(ModelState);
                var result = new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = modelErrors.ToString() };
                return Result(result);
            }

            return Result(await Task.FromResult(_service.Update(entity)));

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Result(await Task.FromResult(_service.Delete(id)));

        }
    }
}