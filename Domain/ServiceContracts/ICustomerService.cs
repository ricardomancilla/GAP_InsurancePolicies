using Domain.EntityModel;
using Domain.ViewModel;
using System;
using System.Linq.Expressions;

namespace Domain.ServiceContracts
{
    public interface ICustomerService
    {
        ResponseEntityVM Find(object id);

        ResponseEntityVM FindBy(Expression<Func<CustomerModel, bool>> predicate);

        ResponseEntityVM GetAll();
    }
}
