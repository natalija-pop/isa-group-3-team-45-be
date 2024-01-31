using AutoMapper;
using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Company.Core.Domain;
using ISAProject.Modules.Company.Core.Domain.RepositoryInterfaces;
using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.Core.UseCases
{
    public class ContractService : MappingService<HospitalContractDto, HospitalContract>, IContractService
    {
        private readonly IContractRepository _repository;

        public ContractService(IMapper mapper, IContractRepository repository) : base(mapper)
        {
            _repository = repository;   
        }
        public Result<HospitalContractDto> Create(HospitalContractDto contract)
        {
            var entity = _repository.Create(MapToDomain(contract));
            return MapToDto(entity);
        }

        public Result<HospitalContract> Update(HospitalContract contract)
        {
            var entity = _repository.Update(contract);
            return entity;
        }
        public Result<List<HospitalContract>> GetAll()
        {
            var contracts = _repository.GetAll();
            return contracts;
        }
    }
}
