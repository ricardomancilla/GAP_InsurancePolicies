using Domain.ServiceContracts;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class CodeController : BaseApiController
    {
        ICodeService _service;

        public CodeController(ICodeService service)
        {
            _service = service;
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> GetCodes(string filter)
        {
            switch (filter)
            {
                case "COVERAGE":
                    return Result(await Task.FromResult(_service.GetCoverageTypeCodes()));
                case "POLICY":
                    return Result(await Task.FromResult(_service.GetPolicyStatusCodes()));
                case "RISK":
                    return Result(await Task.FromResult(_service.GetRiskTypeCodes()));
                case "ASSIGNMENT":
                    return Result(await Task.FromResult(_service.GetAssignmentStatusCodes()));
                default:
                    return Result(new Domain.ViewModel.ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.NotFound });
            }
        }
    }
}
