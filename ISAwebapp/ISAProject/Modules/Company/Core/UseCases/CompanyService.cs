using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;

namespace ISAProject.Modules.Company.Core.UseCases
{
    public class CompanyService: CrudService<CompanyDto, Domain.Company>, ICompanyService
    {
        public CompanyService(ICrudRepository<Domain.Company> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }
    }
}
