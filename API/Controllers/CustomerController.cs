using Domain.EntityModel;
using Domain.ServiceContracts;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Json(new
            {
                CustomerList = await Task.FromResult(_service.GetAll())
            });
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var customer = await Task.FromResult(_service.Find(id));

            if (customer == null)
                return NotFound();

            return Json(customer);
        }

        [ActionName("GetBy")]
        public async Task<IHttpActionResult> GetBy(string filter)
        {
            Expression<Func<CustomerModel, bool>> predicate = (x => x.Identification.Contains(filter)
                || x.FirstName.Contains(filter) || x.LastName.Contains(filter));

            return Json(new
            {
                CustomerList = await Task.FromResult(_service.FindBy(predicate))
            });
        }
    }
}
