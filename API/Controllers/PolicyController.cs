using Domain.EntityModel;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System.Linq;
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
            return Json(new
            {
                PolicyList = await Task.FromResult(_service.GetAll())
            });
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> Get()
        {
            return Json(new
            {
                PolicyList = await Task.FromResult(_service.FindBy(x => x.DeleteDate.Equals(null)).ToList())
            });
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var policy = await Task.FromResult(_service.Find(id));

            if (policy == null)
                return NotFound();

            return Json(policy);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(PolicyModel entity)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder modelErrors = GetModelErrors(ModelState);
                var result = new EntityResult() { Sucess = false, ErrorMessage = modelErrors.ToString() };
                return Content(System.Net.HttpStatusCode.BadRequest, result);
            }

            return Json(new
            {
                Result = await Task.FromResult(_service.Create(entity))
            });

        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(PolicyModel entity)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder modelErrors = GetModelErrors(ModelState);
                var result = new EntityResult() { Sucess = false, ErrorMessage = modelErrors.ToString() };
                return Content(System.Net.HttpStatusCode.BadRequest, result);
            }

            return Json(new
            {
                Result = await Task.FromResult(_service.Update(entity))
            });

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Json(new
            {
                Result = await Task.FromResult(_service.Delete(id))
            });

        }
    }
}