﻿using Domain.EntityModel;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class CustomerPolicyController : BaseApiController
    {
        ICustomerPolicyService _service;

        public CustomerPolicyController(ICustomerPolicyService service)
        {
            _service = service;
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Result(await Task.FromResult(_service.GetAll()));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(CustomerPolicyModel entity)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder modelErrors = GetModelErrors(ModelState);
                var result = new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = modelErrors.ToString() };
                return Result(result);
            }

            return Result(await Task.FromResult(_service.AssignPolicy(entity)));

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Result(await Task.FromResult(_service.CancelPolicy(id)));
        }

        private Expression<Func<CustomerPolicyModel, bool>> getPredicate(CustomerPolicyVM filter)
        {
            int typeCondition = 0;

            if (filter.CustomerID.HasValue)
                typeCondition++;
            if (filter.PolicyID.HasValue)
                typeCondition += 2;

            switch (typeCondition)
            {
                case 1:
                    Expression<Func<CustomerPolicyModel, bool>> predicate1 = (x => x.CustomerID.Equals(filter.CustomerID.Value));
                    return predicate1;
                case 2:
                    Expression<Func<CustomerPolicyModel, bool>> predicate2 = (x => x.PolicyID.Equals(filter.PolicyID.Value));
                    return predicate2;
                case 3:
                    Expression<Func<CustomerPolicyModel, bool>> predicate3 = (x => x.CustomerID.Equals(filter.CustomerID.Value) &&
                        x.Policy.Equals(filter.PolicyID.Value));
                    return predicate3;
                default:
                    Expression<Func<CustomerPolicyModel, bool>> predicate4 = (x => x.CustomerPolicyID > 0);
                    return predicate4;
            }
        }
    }
}
