using AutoMapper;
using Business.Common;
using Domain.EntityModel;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Services
{
    public class PolicyService : IPolicyService
    {
        private IPolicyRepository _repository;
        private ICustomerPolicyRepository _customerPolicyRepository;
        private ICodeService _codeService;
        private IMapper _mapper;

        public PolicyService(IPolicyRepository repository, ICustomerPolicyRepository customerPolicyRepository, ICodeService codeService, IMapper mapper)
        {
            _repository = repository;
            _customerPolicyRepository = customerPolicyRepository;
            _codeService = codeService;
            _mapper = mapper;
        }

        public ResponseEntityVM Find(object id)
        {
            try
            {
                var policy = ((List<PolicyVM>)FindBy(x => x.PolicyID.Equals(id)).Result).FirstOrDefault();

                if (policy == null)
                    return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.NotFound };

                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = policy };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Policies: {ex.Message}" };
            }
        }

        public ResponseEntityVM FindBy(Expression<Func<PolicyModel, bool>> predicate)
        {
            try
            {
                var coverateTypeCodes = ((List<CodeVM>)_codeService.GetCoverageTypeCodes().Result).ToList();
                var riskTypeCodes = ((List<CodeVM>)_codeService.GetRiskTypeCodes().Result).ToList();

                var policyList = _repository.FindBy(predicate).Where(x => x.DeleteDate.Equals(null)).Select(x =>
                    new PolicyVM()
                    {
                        PolicyID = x.PolicyID,
                        CoveragePercentaje = x.CoveragePercentage,
                        CoverageType = coverateTypeCodes.Where(y => y.CodeID.Equals(x.CoverageTypeID)).FirstOrDefault().Code,
                        Description = x.Description,
                        Name = x.Name,
                        Price = x.Price,
                        RiskType = riskTypeCodes.Where(y => y.CodeID.Equals(x.RiskTypeID)).FirstOrDefault().Code,
                        CoverageTerm = x.CoverageTerm
                    }
                );

                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = policyList };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Policies: {ex.Message}" };
            }
        }

        public ResponseEntityVM GetAll()
        {
            try
            {
                var coverateTypeCodes = ((List<CodeVM>)_codeService.GetCoverageTypeCodes().Result).ToList();
                var riskTypeCodes = ((List<CodeVM>)_codeService.GetRiskTypeCodes().Result).ToList();

                var policyList = _repository.GetAll().Select(x => new PolicyVM()
                {
                    PolicyID = x.PolicyID,
                    Name = x.Name,
                    Description = x.Description,
                    CoveragePercentaje = x.CoveragePercentage,
                    CoverageType = coverateTypeCodes.Where(y => y.CodeID.Equals(x.CoverageTypeID)).FirstOrDefault().Code,
                    RiskType = riskTypeCodes.Where(y => y.CodeID.Equals(x.RiskTypeID)).FirstOrDefault().Code,
                    Price = x.Price,
                    CoverageTerm = x.CoverageTerm
                });

                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = policyList };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Policies: {ex.Message}" };
            }
        }

        public ResponseEntityVM Create(PolicyModel entity)
        {
            try
            {
                var highRiskType = RiskTypeEnum.High.ToString("G");
                var highRiskTypeCode = ((List<CodeVM>)_codeService.GetRiskTypeCodes().Result).Where(x => x.Code.Equals(highRiskType)).FirstOrDefault();
                var validateBusinessRuleResult = ValidateBusinessRule(entity, highRiskTypeCode);

                if (validateBusinessRuleResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var entityResult = _repository.Insert(entity);
                    _repository.SaveChanges();
                    return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.Created, Result = entityResult };
                }
                return validateBusinessRuleResult;
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error creating the policy: {ex.Message}" };
            }
        }

        public ResponseEntityVM Update(PolicyModel entity)
        {
            try
            {
                var highRiskType = RiskTypeEnum.High.ToString("G");
                var highRiskTypeCode = ((List<CodeVM>)_codeService.GetRiskTypeCodes().Result).Where(x => x.Code.Equals(highRiskType)).FirstOrDefault();
                var validateBusinessRuleResult = ValidateBusinessRule(entity, highRiskTypeCode);

                if (validateBusinessRuleResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _repository.Update(entity);
                    _repository.SaveChanges();
                    return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.NoContent };
                }
                return validateBusinessRuleResult;
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error updating the policy: {ex.Message}" };
            }
        }

        public ResponseEntityVM Delete(object id)
        {
            try
            {
                var policy = _repository.Find(id);

                if (policy == null)
                    return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.NotFound };

                var validatePolicyNotInUseResult = ValidatePolicyNotInUse(policy);

                if (validatePolicyNotInUseResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _repository.Delete(policy);
                    _repository.SaveChanges();
                    return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.NoContent };
                }
                return validatePolicyNotInUseResult;
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error deleting the policy: {ex.Message}" };
            }
        }

        private ResponseEntityVM ValidateBusinessRule(PolicyModel entity, CodeVM highRiskTypeCode)
        {
            var result = new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK };

            if (entity.RiskTypeID == highRiskTypeCode.CodeID && entity.CoveragePercentage > RiskTypeEnum.High.GetHashCode())
            {
                result.StatusCode = System.Net.HttpStatusCode.Forbidden;
                result.Message = $"The coverage percentage cannot be over {RiskTypeEnum.High.GetHashCode()}% for High Risk coverage type.";
            }

            return result;
        }

        private ResponseEntityVM ValidatePolicyNotInUse(PolicyModel entity)
        {
            var assignedPolicyStatus = PolicyStatusEnum.Assigned.ToString("G");

            var customerPolicyList = _customerPolicyRepository.FindBy(x =>
                x.PolicyID.Equals(entity.PolicyID) &&
                x.Status.Code.Equals(assignedPolicyStatus) &&
                x.DueDate > DateTime.Now).ToList();

            return new ResponseEntityVM()
            {
                StatusCode = customerPolicyList.Count == 0 ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.Forbidden ,
                Message = customerPolicyList.Count > 0 ? "The policy cannot be deleted, there is at least one customer with the policy assigned." : string.Empty
            };
        }
    }
}
