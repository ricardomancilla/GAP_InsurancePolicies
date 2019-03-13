using AutoMapper;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System;
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

        public ResponseEntityVM GetAll()
        {
            try
            {
                var agencyList = _repository.GetAll();
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = _mapper.Map<IEnumerable<AgencyVM>>(agencyList) };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Agencies: {ex.Message}" };
            }
        }
    }
}
