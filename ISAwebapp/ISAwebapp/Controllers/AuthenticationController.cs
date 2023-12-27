using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/users")]
    public class AuthenticationController : BaseApiController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IEmailService _emailService;

        public AuthenticationController(IAuthenticationService authenticationService, IEmailService emailService)
        {
            _authenticationService = authenticationService;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public ActionResult<AuthenticationTokensDto> Register([FromBody] EmployeeRegistrationDto account)
        {
            var result = _authenticationService.RegisterUser(account);
            _emailService.SendActivationEmail(account.Email, result.Value.AccessToken);
            return CreateResponse(result);
        }

        [HttpPost("register-company-admin")]
        public ActionResult<AuthenticationTokensDto> RegisterCompanyAdmin([FromBody] CompanyAdminDto account)
        {
            return CreateResponse(_authenticationService.RegisterCompanyAdmin(account));
        }

        [Authorize(Policy = "SystemAdministratorPolicy")]
        [HttpPost("register-sys-admin")]
        public ActionResult<AuthenticationTokensDto> RegisterSysAdmin([FromBody] AccountRegistrationDto account)
        {
            var result = _authenticationService.RegisterSysAdmin(account);
            _emailService.SendRegistrationInfoEmail(account.Email, result.Value.Password);
            return CreateResponse(result);
        }

        [HttpPost("login")]
        public ActionResult<AuthenticationTokensDto> Login([FromBody] CredentialsDto credentials)
        {
            var result = _authenticationService.Login(credentials);
            return CreateResponse(result);
        }
    }
}
