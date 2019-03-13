using AutoMapper;
using Business.Common;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System;
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

        public ResponseEntityVM GetCoverageTypeCodes()
        {
            var coverageTypeCode = CodeCategoryEnum.COVERAGE_TYPE.ToString("G");
            return GetCodeListMapped(coverageTypeCode);
        }

        public ResponseEntityVM GetPolicyStatusCodes()
        {
            var policyStatusCode = CodeCategoryEnum.POLICY_STATUS.ToString("G");
            return GetCodeListMapped(policyStatusCode);
        }

        public ResponseEntityVM GetRiskTypeCodes()
        {
            var riskTypeCode = CodeCategoryEnum.RISK_TYPE.ToString("G");
            return GetCodeListMapped(riskTypeCode);
        }

        private ResponseEntityVM GetCodeListMapped(string code)
        {
            try
            {
                var codeList = _repository.FindBy(x => x.CodeCategory.Code.Equals(code)).ToList();
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = _mapper.Map<IList<CodeVM>>(codeList) };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Codes: {ex.Message}" };
            }
        }
    }
}
