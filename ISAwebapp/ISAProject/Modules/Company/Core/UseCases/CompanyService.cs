using AutoMapper;
using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Stakeholders.API.Converters;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace ISAProject.Modules.Company.Core.UseCases
{
    public class CompanyService: CrudService<CompanyDto, Domain.Company>, ICompanyService
    {
        private readonly IUserRepository _userRepository;
        public CompanyService(ICrudRepository<Domain.Company> crudRepository, IMapper mapper, IUserRepository userRepository) : base(crudRepository, mapper)
        {
            _userRepository = userRepository;
        }

        public Result<CompanyDto> CreateCompany(CompanyDto companyDto)
        {
            var company = CrudRepository.Create(MapToDomain(companyDto));
            var adminDto = companyDto.Admins.FirstOrDefault();
            var admin = _userRepository.Create(
                UserConverter.ConvertToDomain(adminDto));

            var companyAdmin = _userRepository.Create(new CompanyAdmin(company.Id, admin.Id));
            return MapToDto(company);
        }

        public Result<List<CompanyDto>> Search(string name, string city)
        {
            var searchResults = new List<CompanyDto>();
            var allCompanies = CrudRepository.GetPaged(0, 0).Results;

            foreach (var company in allCompanies)
            {
                if (name != null && company.Name.ToLower().Contains(name?.ToLower()) &&
                    (city != null && company.Address.City.ToLower().Contains(city?.ToLower())))
                {
                    searchResults.Add(MapToDto(company));
                }
                else if(name != null && city == null && company.Name.ToLower().Contains(name?.ToLower()))
                {
                    searchResults.Add(MapToDto(company));
                }
                else if(city != null && name == null && company.Address.City.ToLower().Contains(city?.ToLower()))
                {
                    searchResults.Add(MapToDto(company));
                }
            }

            return searchResults;
        }
    }
}
