using Domain.EntityModel;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.ServiceContracts
{
    public interface ICustomerService
    {
        CustomerVM Find(object id);

        IQueryable<CustomerVM> FindBy(Expression<Func<CustomerModel, bool>> predicate);

        IEnumerable<CustomerVM> GetAll();
    }
}
