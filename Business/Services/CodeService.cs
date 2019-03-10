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
            return _repository.FindByWithRelations(x => x.CodeCategory.Code.Equals(CodeCategoryEnum.COVERAGE_TYPE.ToString("G")));
        }

        public IEnumerable<CodeModel> GetPolicyStatusCodes()
        {
            return _repository.FindByWithRelations(x => x.CodeCategory.Code.Equals(CodeCategoryEnum.POLICY_STATUS.ToString("G")));
        }

        public IEnumerable<CodeModel> GetRiskTypeCodes()
        {
            return _repository.FindByWithRelations(x => x.CodeCategory.Code.Equals(CodeCategoryEnum.RISK_TYPE.ToString("G")));
        }
    }
}
