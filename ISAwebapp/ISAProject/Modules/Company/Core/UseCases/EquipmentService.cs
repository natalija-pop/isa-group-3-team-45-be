using AutoMapper;
using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Company.Core.Domain;

namespace ISAProject.Modules.Company.Core.UseCases
{
    public class EquipmentService: CrudService<EquipmentDto, Equipment>, IEquipmentService
    {
        public EquipmentService(ICrudRepository<Equipment> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }

        public Result<List<EquipmentDto>> Search()
        {
        }
    }
}
