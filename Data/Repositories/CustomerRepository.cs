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
    public class CustomerRepository : Repository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(IContext dbContext)
            :base(dbContext)
        { }
    }
}
