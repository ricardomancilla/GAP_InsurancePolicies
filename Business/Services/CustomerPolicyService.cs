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
    public class CustomerPolicyService : ICustomerPolicyService
    {
        private ICustomerPolicyRepository _repository;
        private ICustomerService _customerService;
        private IPolicyService _policyService;
        private ICodeService _codeService;
        private IMapper _mapper;

        public CustomerPolicyService(ICustomerPolicyRepository repository, ICustomerService customerService, IPolicyService policyService,
            ICodeService codeService, IMapper mapper)
        {
            _repository = repository;
            _customerService = customerService;
            _policyService = policyService;
            _codeService = codeService;
            _mapper = mapper;
        }

        public ResponseEntityVM GetAll()
        {
            try
            {
                var policyAssignedStatus = AssigmentStatusEnum.Assigned.ToString("G");
                var customerPolicyList = _repository.FindBy(x => x.Status.Code.Equals(policyAssignedStatus));

                var result = _mapper.Map<IList<CustomerPolicyVM>>(customerPolicyList);
                result = FindCustomerAndPolicy(result);

                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = result };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Codes: {ex.Message}" };
            }
        }

        public ResponseEntityVM FindBy(Expression<Func<CustomerPolicyModel, bool>> predicate)
        {
            try
            {
                var assignedPolicyStatus = AssigmentStatusEnum.Assigned.ToString("G");
                var assignedPolicyStatusType = ((List<CodeVM>)_codeService.GetPolicyStatusCodes().Result).FirstOrDefault(x => x.Code.Equals(assignedPolicyStatus));

                var customerPolicyList = _repository.FindBy(predicate).Where(x => x.StatusID.Equals(assignedPolicyStatusType.CodeID)).ToList();

                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = _mapper.Map<IList<CustomerPolicyVM>>(customerPolicyList) };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Codes: {ex.Message}" };
            }
        }

        public ResponseEntityVM AssignPolicy(CustomerPolicyModel entity)
        {
            try
            {
                var policyAssignedStatus = AssigmentStatusEnum.Assigned.ToString("G");
                var codeList = ((List<CodeVM>)_codeService.GetAssignmentStatusCodes().Result).FirstOrDefault(x => x.Code.Equals(policyAssignedStatus));

                var associationAlreadyExists = _repository.FindBy(x => x.CustomerID.Equals(entity.CustomerID)
                    && x.PolicyID.Equals(entity.PolicyID)
                    && x.StatusID.Equals(codeList.CodeID)).ToList();

                if (associationAlreadyExists.Count > 0)
                    return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.Conflict, Message = "The customer already has the policy associated." };

                entity.StatusID = codeList.CodeID;

                var entityResult = _repository.Insert(entity);
                _repository.SaveChanges();
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.Created, Result = entityResult };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error assigning the policy: {ex.Message}" };
            }
        }

        public ResponseEntityVM CancelPolicy(object id)
        {
            try
            {
                var cancelledPolicyStatus = AssigmentStatusEnum.Cancelled.ToString("G");
                var cancelledPolicyStatusType = ((List<CodeVM>)_codeService.GetAssignmentStatusCodes().Result).FirstOrDefault(x => x.Code.Equals(cancelledPolicyStatus));

                var customerPolicy = _repository.Find(id);

                if (customerPolicy == null || customerPolicy.StatusID.Equals(cancelledPolicyStatusType.CodeID))
                    return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.NotFound };

                customerPolicy.StatusID = cancelledPolicyStatusType.CodeID;

                _repository.Update(customerPolicy);
                _repository.SaveChanges();
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.NoContent };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error cancelling the policy association: {ex.Message}" };
            }
        }

        private List<CustomerPolicyVM> FindCustomerAndPolicy(IList<CustomerPolicyVM> input)
        {
            var customerList = _customerService.GetAll();
            var policyList = _policyService.GetAll();

            foreach (var item in input)
            {
                item.Customer = ((List<CustomerVM>)customerList.Result).FirstOrDefault(x => x.CustomerID.Equals(item.CustomerID)).Name;
                item.Policy = ((List<PolicyVM>)policyList.Result).FirstOrDefault(x => x.PolicyID.Equals(item.PolicyID)).Name;
            }

            return input.ToList();
        }
    }
}
