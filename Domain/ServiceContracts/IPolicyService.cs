using Domain.EntityModel;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.ServiceContracts
{
    public interface IPolicyService
    {
        ResponseEntityVM Find(object id);

        ResponseEntityVM FindBy(Expression<Func<PolicyModel, bool>> predicate);

        ResponseEntityVM GetAll();

        ResponseEntityVM Create(PolicyModel entity);

        ResponseEntityVM Update(PolicyModel entity);

        ResponseEntityVM Delete(object id);
    }
}
