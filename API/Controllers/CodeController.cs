using Domain.ServiceContracts;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class CodeController : ApiController
    {
        ICodeService _service;

        public CodeController(ICodeService service)
        {
            _service = service;
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> GetCodes()
        {
            return Json(new
            {
                CoverageTypeList = await Task.FromResult(_service.GetCoverageTypeCodes()),
                PolicyStatusLIst = await Task.FromResult(_service.GetPolicyStatusCodes()),
                RiskTypeList = await Task.FromResult(_service.GetRiskTypeCodes())
            });
        }
    }
}
