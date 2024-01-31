using AutoMapper;
using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.Core.Domain;

namespace ISAProject.Modules.Stakeholders.Core.Mappers
{
    public class StakeholderProfile : Profile
    {
        public StakeholderProfile()
        {
            CreateMap<EmployeeRegistrationDto, Employee>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CompanyAdminDto, CompanyAdmin>().ReverseMap();
        }

    }
}
