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
        private ICustomerPolicyRespository _customerPolicyRepository;
        private ICodeService _codeService;

        public PolicyService(IPolicyRepository repository, ICustomerPolicyRespository customerPolicyRepository, ICodeService codeService)
        {
            _repository = repository;
            _customerPolicyRepository = customerPolicyRepository;
            _codeService = codeService;
        }

        public PolicyVM Find(object id)
        {
            return FindBy(x => x.PolicyID.Equals(id)).FirstOrDefault();
        }

        public IQueryable<PolicyVM> FindBy(Expression<Func<PolicyModel, bool>> predicate)
        {
            var coverateTypeCodes = _codeService.GetCoverageTypeCodes().ToList();
            var riskTypeCodes = _codeService.GetRiskTypeCodes().ToList();

            return _repository.FindBy(predicate).Where(x => x.DeleteDate.Equals(null)).Select(x =>
                new PolicyVM()
                {
                    PolicyID = x.PolicyID,
                    CoveragePercentaje = x.CoveragePercentage,
                    CoverageType = coverateTypeCodes.Where(y => y.CodeID.Equals(x.CoverageTypeID)).FirstOrDefault().Code,
                    Description = x.Description,
                    Name = x.Name,
                    PolicyStatusID = x.PolicyStatusID,
                    Price = x.Price,
                    RiskType = riskTypeCodes.Where(y => y.CodeID.Equals(x.RiskTypeID)).FirstOrDefault().Code,
                    Validity = x.CoverageTerm
                }
            );
        }

        public IEnumerable<PolicyVM> GetAll()
        {
            return _repository.GetAll().Select(x => new PolicyVM()
            {
                PolicyID = x.PolicyID,
                Name = x.Name,
                Description = x.Description,
                CoveragePercentaje = x.CoveragePercentage,
                CoverageType = x.CoverageType.Code,
                RiskType = x.RiskType.Code,
                Price = x.Price,
                Validity = x.CoverageTerm,
                PolicyStatusID = x.PolicyStatusID
            });
        }

        public EntityResult Create(PolicyModel entity)
        {
            try
            {
                var highRiskType = RiskTypeEnum.High.ToString("G");
                var highRiskTypeCode = _codeService.GetRiskTypeCodes().Where(x => x.Code.Equals(highRiskType)).FirstOrDefault();
                var validateBusinessRuleResult = ValidateBusinessRule(entity, highRiskTypeCode);

                if (validateBusinessRuleResult.Sucess)
                {
                    _repository.Insert(entity);
                    return new EntityResult() { Sucess = true };
                }
                return validateBusinessRuleResult;
            }
            catch (Exception ex)
            {
                return new EntityResult() { Sucess = false, ErrorMessage = $"There was an error creating the policy: {ex.Message}" };
            }
        }

        public EntityResult Update(PolicyModel entity)
        {
            try
            {
                var highRiskType = RiskTypeEnum.High.ToString("G");
                var highRiskTypeCode = _codeService.GetRiskTypeCodes().Where(x => x.Code.Equals(highRiskType)).FirstOrDefault();
                var validateBusinessRuleResult = ValidateBusinessRule(entity, highRiskTypeCode);

                if (validateBusinessRuleResult.Sucess)
                {
                    _repository.Update(entity);
                    return new EntityResult() { Sucess = true };
                }
                return validateBusinessRuleResult;
            }
            catch (Exception ex)
            {
                return new EntityResult() { Sucess = false, ErrorMessage = $"There was an error updating the policy: {ex.Message}" };
            }
        }

        public EntityResult Delete(object id)
        {
            try
            {
                var policy = _repository.Find(id);

                if(policy == null)
                    return new EntityResult() { Sucess = false, ErrorMessage = "Policy not found." };

                var validatePolicyNotInUseResult = ValidatePolicyNotInUse(policy);

                if (validatePolicyNotInUseResult.Sucess)
                {
                    _repository.Delete(policy);
                    return new EntityResult() { Sucess = true };
                }
                return validatePolicyNotInUseResult;
            }
            catch (Exception ex)
            {
                return new EntityResult() { Sucess = false, ErrorMessage = $"There was an error deleting the policy: {ex.Message}" };
            }
        }

        private EntityResult ValidateBusinessRule(PolicyModel entity, CodeVM highRiskTypeCode)
        {
            var result = new EntityResult() { Sucess = true };

            if (entity.RiskTypeID == highRiskTypeCode.CodeID && entity.CoveragePercentage > RiskTypeEnum.High.GetHashCode())
            {
                result.Sucess = false;
                result.ErrorMessage = $"The coverage percentage cannot be over {RiskTypeEnum.High.GetHashCode()}% for High Risk coverage type.";
            }

            return result;
        }

        private EntityResult ValidatePolicyNotInUse(PolicyModel entity)
        {
            var assignedPolicyStatus = PolicyStatusEnum.Assigned.ToString("G");

            var customerPolicyList = _customerPolicyRepository.FindBy(x =>
                x.PolicyID.Equals(entity.PolicyID) &&
                x.Status.Code.Equals(assignedPolicyStatus) &&
                x.DueDate > DateTime.Now).ToList();

            return new EntityResult()
            {
                Sucess = customerPolicyList.Count == 0,
                ErrorMessage = customerPolicyList.Count > 0 ? "The policy cannot be deleted, there is at least one customer with the policy assigned." : string.Empty
            };
        }
    }
}
