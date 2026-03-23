using AutoMapper;
using HSMS.contracts.Dto;
using HSMS.Domain.Domains;

namespace HSMS.Application.Mapping
{

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
         
            CreateMap<CountryDto, CountryMasters>().ReverseMap();
            CreateMap<CountryMastersDto, CountryMasters>().ReverseMap();
            CreateMap<MainDepartmentMastersDto, MainDepartmentMasters>().ReverseMap();
            CreateMap<QualificationMastersDto,QualificationMasters>().ReverseMap();
        }

    }
}
