using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Company
{
    [Route(("api/company"))]
    public class CompanyController: BaseApiController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService service)
        {
            _companyService = service;
        }

        [HttpPost]
        public ActionResult<CompanyDto> Create([FromBody] CompanyDto companyDto)
        {
            var result = _companyService.Create(companyDto);
            return CreateResponse(result);
        }

    }
}
