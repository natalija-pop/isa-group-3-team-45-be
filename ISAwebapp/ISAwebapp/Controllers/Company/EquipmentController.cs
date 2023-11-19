using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Company
{
    [Route("api/equipment")]
    public class EquipmentController: BaseApiController
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService service)
        {
            _equipmentService = service;
        }

        [HttpGet("getAll")]
        public ActionResult<EquipmentDto> GetPaged([FromQuery] int page, [FromQuery] int pageSize)
        {
            return CreateResponse(_equipmentService.GetPaged(page, pageSize));
        }

        [HttpGet("getSearchResults")]
        public ActionResult<EquipmentDto> GetSearchResults([FromQuery] string searchKeyword)
        {
            return CreateResponse(_equipmentService.Search(searchKeyword));
        }

        [HttpGet("getCompanyEquipment/{companyId:int}")]
        public ActionResult<EquipmentDto> GetByCompanyId([FromQuery] int page, [FromQuery] int pageSize, [FromRoute] int companyId)
        {
            return CreateResponse(_equipmentService.GetByCompanyId(page, pageSize, companyId));
        }
    }
}
