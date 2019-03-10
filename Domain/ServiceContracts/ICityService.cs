using Domain.EntityModel;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.ServiceContracts
{
    public interface ICityService
    {
        IEnumerable<CityVM> GetAll();

        CityVM Find(object id);
    }
}
