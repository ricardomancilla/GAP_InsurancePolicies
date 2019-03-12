using Domain.EntityModel;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ServiceContracts
{
    public interface ICustomerPolicyService
    {
        IEnumerable<CustomerPolicyVM> FindBy(Expression<Func<CustomerPolicyModel, bool>> predicate);

        IEnumerable<CustomerPolicyVM> GetAll();

        EntityResult AssignPolicy(CustomerPolicyModel entity);

        EntityResult CancelPolicy(object id);
    }
}
