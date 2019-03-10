using Domain.EntityModel;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Services
{
    public class PolicyService : IPolicyService
    {
        private IPolicyRepository _repository;
        private ICodeService _codeService;

        public PolicyService(IPolicyRepository repository, ICodeService codeService)
        {
            _repository = repository;
            _codeService = codeService;
        }

        public PolicyVM Find(object id)
        {
            return FindBy(x => x.PolicyID.Equals(id)).FirstOrDefault();
        }

        public IQueryable<PolicyVM> FindBy(Expression<Func<PolicyModel, bool>> predicate)
        {
            var coverateTypeCodes = _codeService.GetCoverageTypeCodes().ToList();
            var riskTypeCodes = _codeService.GetRiskTypeCodes().ToList();

            return _repository.FindBy(predicate).Select(x =>
                new PolicyVM()
                {
                    PolicyID = x.PolicyID,
                    CoveragePercentaje = x.CoveragePercentaje,
                    CoverageType = coverateTypeCodes.Where(y => y.CodeID.Equals(x.CoverageTypeID)).FirstOrDefault().Code,
                    Description = x.Description,
                    Name = x.Name,
                    PolicyStatusID =x.PolicyStatusID,
                    Price = x.Price,
                    RiskType = riskTypeCodes.Where(y => y.CodeID.Equals(x.RiskTypeID)).FirstOrDefault().Code,
                    Validity = x.Validity
                }
            );
        }

        public IEnumerable<PolicyVM> GetAll()
        {
            var entityList = _repository.GetAll();
            return null;
        }

        public void Insert(PolicyModel entity)
        {
            //Realizar validaciones
            _repository.Insert(entity);
        }

        public void Update(PolicyModel entity)
        {
            //Realizar validaciones
            _repository.Update(entity);
        }

        public void Delete(object id)
        {
            var policy = _repository.Find(id);
            //Validar que la póliza no esté siendo usada
            _repository.Delete(policy);
        }
    }
}
