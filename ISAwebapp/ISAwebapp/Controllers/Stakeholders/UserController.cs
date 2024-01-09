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

        [HttpGet("getAll")]
        public ActionResult<UserDto> GetPaged([FromQuery] int page, [FromQuery] int pageSize)
        {
            return CreateResponse(_userService.GetPaged(page, pageSize));
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

        [HttpPut("changePassword")]
        public ActionResult<bool> ChangePassword([FromBody] PasswordChangeDto passwordChangeDto)
        {
            return CreateResponse(_userService.ChangePassword(passwordChangeDto));
        }
    }
}