using Domain.EntityModel;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using System.Collections.Generic;

namespace Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository _respository;

        public DepartmentService(IDepartmentRepository respository)
        {
            _respository = respository;
        }

        public IEnumerable<DepartmentModel> GetAll()
        {
            return _respository.GetAll();
        }
    }
}
