using AutoMapper;
using ISAProject.Modules.Company.API.Converters;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.Core.Domain;

namespace ISAProject.Modules.Company.Core.Mappers
{
    public class CompanyProfile: Profile
    {
        public CompanyProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<WorkingHours, WorkingHoursDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();

            CreateMap<CompanyDto, Domain.Company>()
                .ForMember(dest => dest.Address, opt =>
                    {
                        opt.PreCondition(x => x.Address != null);
                        opt.MapFrom(src =>
                            new Address(
                                src.Address.Street,
                                src.Address.Number,
                                src.Address.City,
                                src.Address.Country
                            ));
                    }
                )
                .ForMember(dest => dest.WorkingHours, opt =>
                {
                    opt.PreCondition(x => x.WorkingHours != null);
                    opt.MapFrom(src => WorkingHoursConverter.ToDomain(src.WorkingHours));
                });


            CreateMap<Domain.Company, CompanyDto>()
                .ForMember(dest => dest.Address, opt =>
                {
                    opt.PreCondition(x => x.Address != null);
                    opt.MapFrom(src =>
                        new AddressDto
                        {
                            Street = src.Address.Street,
                            Number = src.Address.Number,
                            City = src.Address.City,
                            Country = src.Address.Country
                        });
                })
                .ForMember(dest => dest.WorkingHours, opt =>
                {
                    opt.PreCondition(x => x.WorkingHours != null);
                    opt.MapFrom(src => WorkingHoursConverter.ToDto(src.WorkingHours));
                });
        }
    }
}
