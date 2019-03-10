using Domain.EntityModel;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public CustomerModel Find(object id)
        {
            return _repository.Find(id);
        }

        public IQueryable<CustomerModel> FindBy(Expression<Func<CustomerModel, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
