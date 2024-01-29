using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Dtos;

namespace ISAProject.Modules.Company.API.Public
{
    public interface IEquipmentService
    {
        Result<EquipmentDto> Get(int id);
        Result<EquipmentDto> Create(EquipmentDto equipmentDto);
        Result<EquipmentDto> Update(EquipmentDto equipmentDto);
        Result Delete(int id);
        Result<PagedResult<EquipmentDto>> GetPaged(int page, int pageSize);
        Result<List<EquipmentDto>> Search(string searchKeyword);
        Result<List<EquipmentDto>> GetByCompanyId(int page, int pageSize, long companyId);
        void UpdateProcessed(ICollection<EquipmentDto>? processedEquipment);
    }
}

