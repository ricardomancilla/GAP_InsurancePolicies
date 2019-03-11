using AutoMapper;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System.Collections.Generic;

namespace Business.Services
{
    public class AgencyService : IAgencyService
    {
        private IAgencyRepository _repository;
        private IMapper _mapper;

        public AgencyService(IAgencyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<AgencyVM> GetAll()
        {
            var agencyList = _repository.GetAll();
            return _mapper.Map<IEnumerable<AgencyVM>>(agencyList);
        }
    }
}
