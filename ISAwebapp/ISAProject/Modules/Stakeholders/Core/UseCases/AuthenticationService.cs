using FluentResults;
using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;

namespace ISAProject.Modules.Stakeholders.Core.UseCases
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticationService(ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        public Result<AuthenticationTokensDto> Login(CredentialsDto credentials)
        {
            throw new NotImplementedException();
        }
    }
}
