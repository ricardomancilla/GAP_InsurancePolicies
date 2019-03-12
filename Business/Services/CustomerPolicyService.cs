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
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CustomerPolicyService : ICustomerPolicyService
    {
        private ICustomerPolicyRepository _repository;
        private ICodeService _codeService;
        private IMapper _mapper;

        public CustomerPolicyService(ICustomerPolicyRepository repository, ICodeService codeService, IMapper mapper)
        {
            _repository = repository;
            _codeService = codeService;
            _mapper = mapper;
        }

        public IEnumerable<CustomerPolicyVM> GetAll()
        {
            var policyAssignedStatus = PolicyStatusEnum.Assigned.ToString("G");
            var customerPolicyList = _repository.FindBy(x => x.Status.Code.Equals(policyAssignedStatus));

            return _mapper.Map<IList<CustomerPolicyVM>>(customerPolicyList);
        }

        public IEnumerable<CustomerPolicyVM> FindBy(Expression<Func<CustomerPolicyModel, bool>> predicate)
        {
            var assignedPolicyStatus = PolicyStatusEnum.Assigned.ToString("G");
            var assignedPolicyStatusType = _codeService.GetPolicyStatusCodes().FirstOrDefault(x => x.Code.Equals(assignedPolicyStatus));

            var customerPolicyList = _repository.FindBy(predicate).Where(x => x.StatusID.Equals(assignedPolicyStatusType.CodeID)).ToList();

            return _mapper.Map<IList<CustomerPolicyVM>>(customerPolicyList);
        }

        public EntityResult AssignPolicy(CustomerPolicyModel entity)
        {
            try
            {
                var policyAssignedStatus = PolicyStatusEnum.Assigned.ToString("G");
                var codeList = _codeService.GetPolicyStatusCodes().FirstOrDefault(x => x.Code.Equals(policyAssignedStatus));

                var associationAlreadyExists = _repository.FindBy(x => x.CustomerID.Equals(entity.CustomerID)
                    && x.PolicyID.Equals(entity.PolicyID)
                    && x.StatusID.Equals(codeList.CodeID)).ToList();

                if (associationAlreadyExists.Count > 0)
                    return new EntityResult() { Sucess = false, ErrorMessage = "The customer already has the policy associated." };

                _repository.Insert(entity);
                _repository.SaveChanges();
                return new EntityResult() { Sucess = true };
            }
            catch(Exception ex)
            {
                return new EntityResult() { Sucess = false, ErrorMessage = $"There was an error assigning the policy: {ex.Message}" };
            }
        }

        public EntityResult CancelPolicy(object id)
        {
            try
            {
                var cancelledPolicyStatus = PolicyStatusEnum.Cancelled.ToString("G");
                var cancelledPolicyStatusType = _codeService.GetPolicyStatusCodes().FirstOrDefault(x => x.Code.Equals(cancelledPolicyStatus));

                var customerPolicy = _repository.Find(id);

                customerPolicy.LastUpdateDate = DateTime.Now;
                customerPolicy.StatusID = cancelledPolicyStatusType.CodeID;

                _repository.Update(customerPolicy);
                _repository.SaveChanges();
                return new EntityResult() { Sucess = true };
            }
            catch (Exception ex)
            {
                return new EntityResult() { Sucess = false, ErrorMessage = $"There was an error cancelling the policy association: {ex.Message}" };
            }
        }
    }
}
