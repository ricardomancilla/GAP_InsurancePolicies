using Domain.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.ServiceContracts
{
    public interface ICityService
    {
        IEnumerable<CityModel> GetAll();

        IEnumerable<CityModel> Find(Expression<Func<CityModel, bool>> predicate);
    }
}
