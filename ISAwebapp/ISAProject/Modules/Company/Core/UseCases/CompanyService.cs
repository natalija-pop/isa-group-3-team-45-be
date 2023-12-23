using AutoMapper;
using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Converters;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace ISAProject.Modules.Company.Core.UseCases
{
    public class CompanyService: CrudService<CompanyDto, Domain.Company>, ICompanyService
    {
        private readonly ICompanyAdminRepo _companyAdminsRepository;
        public CompanyService(ICrudRepository<Domain.Company> crudRepository, IMapper mapper, ICompanyAdminRepo userRepository) : base(crudRepository, mapper)
        {
            _companyAdminsRepository = userRepository;
        }

        public Result<CompanyDto> CreateCompany(CompanyDto companyDto)
        {
            var company = CrudRepository.Create(MapToDomain(companyDto));
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

        public Result<List<EquipmentDto>> SearchCompanyEquipment(int companyId, string name)
        {
            var searchResults = new List<EquipmentDto>();
            var company = CrudRepository.Get(companyId);
            var companyEquipment = company.Equipment;

            foreach (var equipment in companyEquipment)
            {
                if (name != null && equipment.Name.ToLower().Contains(name?.ToLower()))
                {
                    searchResults.Add(EquipmentConverter.ToDto(equipment));
                }
            }
            return searchResults;
        }
    }
}
