using Domain.ViewModel;
using System.Collections.Generic;

namespace Domain.ServiceContracts
{
    public interface ICodeService
    {
        ResponseEntityVM GetRiskTypeCodes();

        ResponseEntityVM GetCoverageTypeCodes();

        ResponseEntityVM GetPolicyStatusCodes();

        ResponseEntityVM GetAssignmentStatusCodes();
    }
}
