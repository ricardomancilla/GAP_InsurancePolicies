using Data.Interfaces;
using Domain.EntityModel;
using Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class CustomerPolicyRespository : Repository<CustomerPolicyModel>, ICustomerPolicyRespository
    {
        public CustomerPolicyRespository(IContext dbContext)
            :base(dbContext)
        { }
    }
}
