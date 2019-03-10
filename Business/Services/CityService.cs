using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class CityService : ICityService
    {
        private ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public CityVM Find(object id)
        {
            var city = _repository.Find(id);

            if (city == null)
                return null;

            return new CityVM()
            {
                CityID = city.CityID,
                DepartmentID = city.DepartmentID,
                Name = city.Name
            };
        }

        public IEnumerable<CityVM> GetAll()
        {
            return _repository.GetAll().Select(x => new CityVM()
            {
                CityID = x.CityID,
                DepartmentID = x.DepartmentID,
                Name = x.Name
            });
        }
    }
}
