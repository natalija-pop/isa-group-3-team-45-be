using AutoMapper;
using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace ISAProject.Modules.Stakeholders.Core.UseCases
{
    public class EmployeeService: MappingService<EmployeeRegistrationDto, Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IMapper mapper, IEmployeeRepository repository) : base(mapper)
        {
            _employeeRepository = repository;
        }

        public Result<EmployeeRegistrationDto> Get(int id)
        {
            return MapToDto(_employeeRepository.Get(id));
        }

        public Result<EmployeeRegistrationDto> Update(EmployeeRegistrationDto employee)
        {
            var entity = _employeeRepository.Update(MapToDomain(employee));
            return MapToDto(entity);
        }
    }
}