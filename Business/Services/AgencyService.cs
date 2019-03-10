using Domain.EntityModel;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using System.Collections.Generic;

namespace Business.Services
{
    public class AgencyService : IAgencyService
    {
        private IAgencyRepository _repository;

        public AgencyService(IAgencyRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AgencyModel> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
