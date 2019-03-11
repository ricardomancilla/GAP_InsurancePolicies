using Domain.ViewModel;
using System.Collections.Generic;

namespace Domain.ServiceContracts
{
    public interface IAgencyService
    {
        IEnumerable<AgencyVM> GetAll();
    }
}
