using AutoMapper;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.Core.Domain;

namespace ISAProject.Modules.Company.Core.Mappers
{
    public class EquipmentProfile : Profile
    {

        public EquipmentProfile()
        {
            CreateMap<EquipmentDto, Equipment>();
            CreateMap<Equipment, EquipmentDto>();
        }

    }
}
