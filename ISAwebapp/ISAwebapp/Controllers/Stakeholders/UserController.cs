using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Stakeholders
{
    [Route(("api/user"))]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost]
        public ActionResult<UserDto> Create([FromBody] UserDto userDto)
        {
            var result = _userService.Create(userDto);
            return CreateResponse(result);
        }

        [HttpPost("createCompanyAdmin/{companyId:int}")]
        public ActionResult<UserDto> CreateNewCompanyAdmin([FromBody] UserDto userDto, [FromRoute] int companyId)
        {
            return CreateResponse(_userService.AddNewCompanyAdmin(userDto, companyId));
        }

        [HttpGet("getAll")]
        public ActionResult<UserDto> GetPaged([FromQuery] int page, [FromQuery] int pageSize)
        {
            return CreateResponse(_userService.GetPaged(page, pageSize));
        }

        [HttpGet("getCompanyAdmins/{companyId:int}")]
        public ActionResult<UserDto> GetCompanyAdmins([FromRoute] int companyId)
        {
            return CreateResponse(_userService.GetCompanyAdmins(companyId));
        }


        [HttpGet("get/{userId:int}")]
        public ActionResult<UserDto> Get([FromRoute] int userId)
        {
            return CreateResponse(_userService.Get(userId));
        }

        [HttpPut("{userId:int}")]
        public ActionResult<UserDto> Update([FromBody] UserDto userDto)
        {
            return CreateResponse(_userService.Update(userDto));
        }

        [HttpDelete("delete/{userId:int}")]
        public ActionResult<UserDto> Delete([FromRoute] int userId)
        {
            return CreateResponse(_userService.Delete(userId));
        }
    }
}
