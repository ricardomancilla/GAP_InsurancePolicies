using Domain.EntityModel;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public CustomerVM Find(object id)
        {
            var customer = _repository.Find(id);

            if (customer == null)
                return null;

            return new CustomerVM()
            {
                CustomerID = customer.CustomerID,
                Identification = customer.Identification,
                Name = $"{customer.FirstName} {customer.LastName}",
                MobilePhoneNumber = customer.MobilePhoneNumber,
                EmailAddress = customer.EmailAddress
            };
        }

        public IQueryable<CustomerVM> FindBy(Expression<Func<CustomerModel, bool>> predicate)
        {
            return _repository.FindBy(predicate).Select(x => new CustomerVM()
            {
                CustomerID = x.CustomerID,
                Identification = x.Identification,
                Name = x.FirstName + " " + x.LastName,
                MobilePhoneNumber = x.MobilePhoneNumber,
                EmailAddress = x.EmailAddress
            });
        }

        public IEnumerable<CustomerVM> GetAll()
        {
            return _repository.GetAll().Select(x => new CustomerVM()
            {
                CustomerID = x.CustomerID,
                Identification = x.Identification,
                Name = $"{x.FirstName} {x.LastName}",
                MobilePhoneNumber = x.MobilePhoneNumber,
                EmailAddress = x.EmailAddress
            });
        }
    }
}
