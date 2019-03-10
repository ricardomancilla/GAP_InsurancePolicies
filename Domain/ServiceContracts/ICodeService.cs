using Domain.ViewModel;
using System.Collections.Generic;

namespace Domain.ServiceContracts
{
    public interface ICodeService
    {
        IEnumerable<CodeVM> GetRiskTypeCodes();

        IEnumerable<CodeVM> GetCoverageTypeCodes();

        IEnumerable<CodeVM> GetPolicyStatusCodes();
    }
}
