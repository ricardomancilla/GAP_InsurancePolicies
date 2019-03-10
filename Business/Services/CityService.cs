using Domain.EntityModel;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Services
{
    public class CityService : ICityService
    {
        private ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<CityModel> Find(Expression<Func<CityModel, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public IEnumerable<CityModel> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
