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
        PolicyVM Find(object id);

        IQueryable<PolicyVM> FindBy(Expression<Func<PolicyModel, bool>> predicate);

        IEnumerable<PolicyVM> GetAll();

        void Insert(PolicyModel entity);

        void Update(PolicyModel entity);

        void Delete(object id);
    }
}
