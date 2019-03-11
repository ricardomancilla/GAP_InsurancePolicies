using AutoMapper;
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
        private IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CustomerVM Find(object id)
        {
            var customer = _repository.Find(id);

            if (customer == null)
                return null;

            return _mapper.Map<CustomerVM>(customer);
        }

        public IEnumerable<CustomerVM> FindBy(Expression<Func<CustomerModel, bool>> predicate)
        {
            var customerList = _repository.FindBy(predicate).ToList();
            return _mapper.Map<IQueryable<CustomerVM>>(customerList);
        }

        public IEnumerable<CustomerVM> GetAll()
        {
            var customerList = _repository.GetAll();
            return _mapper.Map<IList<CustomerVM>>(customerList);
        }
    }
}
