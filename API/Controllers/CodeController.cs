using Domain.ServiceContracts;
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

        public IHttpActionResult GetCodes()
        {
            return Json(new
            {
                CoverageTypeList = _service.GetCoverageTypeCodes(),
                PolicyStatusLIst = _service.GetPolicyStatusCodes(),
                RiskTypeList = _service.GetRiskTypeCodes()
            });
        }
    }
}
