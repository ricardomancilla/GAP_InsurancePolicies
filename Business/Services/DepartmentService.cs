using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository _respository;

        public DepartmentService(IDepartmentRepository respository)
        {
            _respository = respository;
        }

        public IEnumerable<DepartmentVM> GetAll()
        {
            return _respository.GetAll().Select(x => new DepartmentVM()
            {
                DepartmentID = x.DepartmentID,
                Name = x.Name,
                PhoneCode = x.PhoneCode
            });
        }
    }
}
