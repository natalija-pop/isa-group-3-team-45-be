using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Dtos;

namespace ISAProject.Modules.Company.API.Public
{
    public interface ICompanyService
    {
        Result<CompanyDto> Create(CompanyDto companyDto);
        Result<CompanyDto> Get(int id);
        Result<CompanyDto> Update(CompanyDto companyDto);
        Result Delete(int id);
        Result<PagedResult<CompanyDto>> GetPaged(int page, int pageSize);
    }
}
