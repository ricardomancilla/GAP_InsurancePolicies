using AutoMapper;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _respository;
        private IMapper _mapper;

        public DepartmentService(IDepartmentRepository respository, IMapper mapper)
        {
            _respository = respository;
            _mapper = mapper;
        }

        public IEnumerable<DepartmentVM> GetAll()
        {
            var departmentList = _respository.GetAll();
            return _mapper.Map<IList<DepartmentVM>>(departmentList);
        }
    }
}
