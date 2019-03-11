using AutoMapper;
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
        private IMapper _mapper;

        public CodeService(ICodeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CodeVM> GetCoverageTypeCodes()
        {
            var coverageTypeCode = CodeCategoryEnum.COVERAGE_TYPE.ToString("G");
            return GetCodeListMapped(coverageTypeCode);
        }

        public IEnumerable<CodeVM> GetPolicyStatusCodes()
        {
            var policyStatusCode = CodeCategoryEnum.POLICY_STATUS.ToString("G");
            return GetCodeListMapped(policyStatusCode);
        }

        public IEnumerable<CodeVM> GetRiskTypeCodes()
        {
            var riskTypeCode = CodeCategoryEnum.RISK_TYPE.ToString("G");
            return GetCodeListMapped(riskTypeCode);
        }

        private IEnumerable<CodeVM> GetCodeListMapped(string code)
        {
            var codeList = _repository.FindBy(x => x.CodeCategory.Code.Equals(code)).ToList();
            return _mapper.Map<IList<CodeVM>>(codeList);
        }
    }
}
