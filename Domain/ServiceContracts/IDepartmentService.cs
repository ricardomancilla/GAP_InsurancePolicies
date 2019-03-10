using Domain.ViewModel;
using System.Collections.Generic;

namespace Domain.ServiceContracts
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentVM> GetAll();
    }
}
