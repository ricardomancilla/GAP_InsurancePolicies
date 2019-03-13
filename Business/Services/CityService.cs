using AutoMapper;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System;
using System.Collections.Generic;

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

        public ResponseEntityVM Find(object id)
        {
            try
            {
                var city = _repository.Find(id);

                if (city == null)
                    return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.NotFound };

                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = _mapper.Map<CityVM>(city) };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Cities: {ex.Message}" };
            }
        }

        public ResponseEntityVM GetAll()
        {
            try
            {
                var cityList = _repository.GetAll();
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = _mapper.Map<IList<CityVM>>(cityList) };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Cities: {ex.Message}" };
            }
        }
    }
}
