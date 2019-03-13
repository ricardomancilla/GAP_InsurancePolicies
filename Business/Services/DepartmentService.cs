using AutoMapper;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _repository;
        private IMapper _mapper;

        public DepartmentService(IDepartmentRepository respository, IMapper mapper)
        {
            _repository = respository;
            _mapper = mapper;
        }

        public ResponseEntityVM GetAll()
        {
            try
            {
                var departmentList = _repository.GetAll();
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.OK, Result = _mapper.Map<IList<DepartmentVM>>(departmentList) };
            }
            catch (Exception ex)
            {
                return new ResponseEntityVM() { StatusCode = System.Net.HttpStatusCode.InternalServerError, Message = $"There was an error getting the Departments: {ex.Message}" };
            }
        }
    }
}
