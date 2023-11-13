using Explorer.Stakeholders.API.Public;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticationService(ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }
    }
}
