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

        public ResponseEntityVM Find(object id)
        {
            try
            {
                var customer = _repository.Find(id);

                if (customer == null)
                    return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.NotFound };

                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = _mapper.Map<CustomerVM>(customer) };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Customer: {ex.Message}" };
            }
        }

        public ResponseEntityVM FindBy(Expression<Func<CustomerModel, bool>> predicate)
        {
            try
            {
                var customerList = _repository.FindBy(predicate).ToList();
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = _mapper.Map<IQueryable<CustomerVM>>(customerList) };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Customer: {ex.Message}" };
            }
        }

        public ResponseEntityVM GetAll()
        {
            try
            {
                var customerList = _repository.GetAll();
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = _mapper.Map<IList<CustomerVM>>(customerList) };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Customers: {ex.Message}" };
            }
        }
    }
}
