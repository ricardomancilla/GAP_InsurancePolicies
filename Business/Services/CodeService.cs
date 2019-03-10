using Business.Common;
using Domain.EntityModel;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using System.Collections.Generic;

namespace Business.Services
{
    public class CodeService : ICodeService
    {
        private ICodeRepository _repository;

        public CodeService(ICodeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CodeModel> GetCoverageTypeCodes()
        {
            var coverageTypeCode = CodeCategoryEnum.COVERAGE_TYPE.ToString("G");
            return _repository.FindBy(x => x.CodeCategory.Code.Equals(coverageTypeCode));
        }

        public IEnumerable<CodeModel> GetPolicyStatusCodes()
        {
            var policyStatusCode = CodeCategoryEnum.POLICY_STATUS.ToString("G");
            return _repository.FindBy(x => x.CodeCategory.Code.Equals(policyStatusCode));
        }

        public IEnumerable<CodeModel> GetRiskTypeCodes()
        {
            var riskTypeCode = CodeCategoryEnum.RISK_TYPE.ToString("G");
            return _repository.FindBy(x => x.CodeCategory.Code.Equals(riskTypeCode));
        }
    }
}
