using Domain.EntityModel;
using System.Collections.Generic;

namespace Domain.ServiceContracts
{
    public interface IAgencyService
    {
        IEnumerable<AgencyModel> GetAll();
    }
}
