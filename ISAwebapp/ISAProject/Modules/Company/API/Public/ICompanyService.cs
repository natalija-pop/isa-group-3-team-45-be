using FluentResults;
using ISAProject.Modules.Company.API.Dtos;

namespace ISAProject.Modules.Company.API.Public
{
    public interface ICompanyService
    {
        Result<CompanyDto> Create(CompanyDto companyDto);
    }
}
