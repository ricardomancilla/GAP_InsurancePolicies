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
        ResponseEntityVM FindBy(Expression<Func<CustomerPolicyModel, bool>> predicate);

        ResponseEntityVM GetAll();

        ResponseEntityVM AssignPolicy(CustomerPolicyModel entity);

        ResponseEntityVM CancelPolicy(object id);
    }
}
