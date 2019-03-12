using System.Text;
using System.Web.Http;

namespace API.Controllers
{
    public class BaseApiController : ApiController
    {
        protected StringBuilder GetModelErrors(System.Web.Http.ModelBinding.ModelStateDictionary ModelState)
        {
            StringBuilder modelErrors = new StringBuilder();
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    modelErrors.AppendLine(error.ErrorMessage);
                }
            }
            return modelErrors;
        }
    }
}
