using AutoMapper;
using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Configuration.Infrastructure.Database;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Company.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISAProject.Modules.Company.Core.UseCases
{
    public class EquipmentService: CrudService<EquipmentDto, Equipment>, IEquipmentService
    {
        public EquipmentService(ICrudRepository<Equipment> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }

        public Result<List<EquipmentDto>> Search(string searchKeyword)
        {
            Predicate<Equipment> searchPredicate = x => x.Name.ToLower()
                .Contains(searchKeyword.ToLower());

            var equipment = CrudRepository.GetSearchResults(searchPredicate);
            return MapToDto(equipment);
        }

        public Result<List<EquipmentDto>> GetByCompanyId(int page, int pageSize, long companyId)
        {
            var pagedResult = CrudRepository.GetPaged(page, pageSize);
            var filteredResult = pagedResult.Results.Where(e => e.CompanyId == companyId).ToList();

            return MapToDto(filteredResult);
        }
    }
}
