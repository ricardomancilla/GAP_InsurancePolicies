using AutoMapper;
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
        private IMapper _mapper;

        public CityService(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CityVM Find(object id)
        {
            var city = _repository.Find(id);

            if (city == null)
                return null;

            return _mapper.Map<CityVM>(city);
        }

        public IEnumerable<CityVM> GetAll()
        {
            var cityList = _repository.GetAll();
            return _mapper.Map<IList<CityVM>>(cityList);
        }
    }
}
