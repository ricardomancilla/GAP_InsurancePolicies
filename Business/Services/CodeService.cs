using Business.Common;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class CodeService : ICodeService
    {
        private ICodeRepository _repository;

        public CodeService(ICodeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CodeVM> GetCoverageTypeCodes()
        {
            var coverageTypeCode = CodeCategoryEnum.COVERAGE_TYPE.ToString("G");
            return _repository.FindBy(x => x.CodeCategory.Code.Equals(coverageTypeCode)).Select(x => new CodeVM()
            {
                CodeID = x.CodeID,
                Code = x.Code
            });
        }

        public IEnumerable<CodeVM> GetPolicyStatusCodes()
        {
            var policyStatusCode = CodeCategoryEnum.POLICY_STATUS.ToString("G");
            return _repository.FindBy(x => x.CodeCategory.Code.Equals(policyStatusCode)).Select(x => new CodeVM()
            {
                CodeID = x.CodeID,
                Code = x.Code
            });
        }

        public IEnumerable<CodeVM> GetRiskTypeCodes()
        {
            var riskTypeCode = CodeCategoryEnum.RISK_TYPE.ToString("G");
            return _repository.FindBy(x => x.CodeCategory.Code.Equals(riskTypeCode)).Select(x => new CodeVM()
            {
                CodeID = x.CodeID,
                Code = x.Code
            });
        }
    }
}
