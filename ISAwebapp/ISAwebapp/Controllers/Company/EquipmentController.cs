using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Company.Core.UseCases;
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

        [HttpPost("create")]
        public ActionResult<EquipmentDto> Create([FromBody] EquipmentDto equipmentDto)
        {
            equipmentDto.Company = null;
            var result = _equipmentService.Create(equipmentDto);
            return CreateResponse(result);
        }

        [HttpDelete("delete/{equipmentId:int}")]
        public ActionResult<EquipmentDto> Delete([FromRoute] int equipmentId)
        {
            return CreateResponse(_equipmentService.Delete(equipmentId));
        }
    }
}
