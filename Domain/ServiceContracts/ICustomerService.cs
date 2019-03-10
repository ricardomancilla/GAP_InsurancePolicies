using Domain.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.ServiceContracts
{
    public interface ICustomerService
    {
        CustomerModel Find(object id);

        IQueryable<CustomerModel> FindBy(Expression<Func<CustomerModel, bool>> predicate);

        IEnumerable<CustomerModel> GetAll();
    }
}
