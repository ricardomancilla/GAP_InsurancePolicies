using Domain.EntityModel;
using System.Collections.Generic;

namespace Domain.ServiceContracts
{
    public interface ICodeService
    {
        IEnumerable<CodeModel> GetRiskTypeCodes();

        IEnumerable<CodeModel> GetCoverageTypeCodes();

        IEnumerable<CodeModel> GetPolicyStatusCodes();
    }
}
