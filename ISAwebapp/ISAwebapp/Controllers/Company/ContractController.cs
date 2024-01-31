using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Company.Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Company
{
    [Route("api/contract")]
    public class ContractController : BaseApiController
    {
        private readonly IContractService _contractService;
        public ContractController(IContractService service)
        {
            _contractService = service;
        }

        [HttpPost]
        public ActionResult<HospitalContractDto> Create([FromBody] HospitalContractDto contractDto)
        {
            var result = _contractService.Create(contractDto);
            return CreateResponse(result);
        }
    }
}
