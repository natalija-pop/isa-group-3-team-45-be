using AutoMapper;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.Core.Mappers
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<HospitalContract, HospitalContractDto>().ReverseMap();

        }
    }
}
