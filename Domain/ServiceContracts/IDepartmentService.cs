using Domain.EntityModel;
using System.Collections.Generic;

namespace Domain.ServiceContracts
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentModel> GetAll();
    }
}
