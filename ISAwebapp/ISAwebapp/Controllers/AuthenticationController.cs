using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.UseCases;
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
        public ActionResult<AuthenticationTokensDto> RegisterTourist([FromBody] UserRegistrationDto account)
        {
            var result = _authenticationService.RegisterUser(account);
            _emailService.SendActivationEmail(account.Email, result.Value.AccessToken);
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
