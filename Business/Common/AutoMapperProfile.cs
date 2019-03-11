using AutoMapper;
using Domain.EntityModel;
using Domain.ViewModel;

namespace Business.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CityModel, CityVM>();
            
            CreateMap<CodeModel, CodeVM>();
            
            CreateMap<CustomerModel, CustomerVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));

            CreateMap<DepartmentModel, DepartmentVM>();
            
            CreateMap<PolicyModel, PolicyVM>();

            CreateMap<UserModel, UserVM>();
        }
    }
}
