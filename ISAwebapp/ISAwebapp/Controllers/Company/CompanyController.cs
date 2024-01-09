using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Stakeholders.API.Dtos;
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
            var result = _companyService.CreateCompany(companyDto);
            return CreateResponse(result);
        }

        [HttpGet("getAll")]
        public ActionResult<CompanyDto> GetPaged([FromQuery] int page, [FromQuery] int pageSize)
        {
            return CreateResponse(_companyService.GetPaged(page, pageSize));
        }

        [HttpGet("get/{companyId:int}")]
        public ActionResult<CompanyDto> Get([FromRoute] int companyId)
        {
            return CreateResponse(_companyService.Get(companyId));
        }

        [HttpPut("{companyId:int}")]
        public ActionResult<CompanyDto> Update([FromBody] CompanyDto companyDto)
        {
            return CreateResponse(_companyService.Update(companyDto));
        }

        [HttpDelete("delete/{companyId:int}")]
        public ActionResult<CompanyDto> Delete([FromRoute] int companyId)
        {
            return CreateResponse(_companyService.Delete(companyId));
        }

        [HttpGet("getSearchResults")]
        public ActionResult<EquipmentDto> GetSearchResults([FromQuery] string? name, [FromQuery] string? city)
        {
            return CreateResponse(_companyService.Search(name, city));
        }

        [HttpGet("getCompanyEquipmentSearchResults/{companyId:int}")]
        public ActionResult<EquipmentDto> GetCompanyEquipmentSearchResults([FromRoute] int companyId, [FromQuery] string? searchKeyword)
        {
            return CreateResponse(_companyService.SearchCompanyEquipment(companyId, searchKeyword));
        }

        [HttpGet("get-company-admins/{companyId:int}")]
        public ActionResult<CompanyAdminDto> GetCompanyAdmins([FromRoute] int companyId)
        {
            return CreateResponse(_companyService.GetCompanyAdmins(companyId));
        }

    }
}
