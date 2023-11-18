using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;
using System;

namespace ISAProject.Modules.Stakeholders.Core.UseCases
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(ITokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }

        public Result<AuthenticationTokensDto> Login(CredentialsDto credentials)
        {
            var user = _userRepository.GetActiveUserByEmail(credentials.Email);
            if (user == null || credentials.Password != user.Password) return Result.Fail(FailureCode.NotFound);
            return _tokenGenerator.GenerateAccessToken(user);
        }

        public Result<AuthenticationTokensDto> RegisterUser(UserDto account)
        {
            if (_userRepository.Exists(account.Email)) return Result.Fail(FailureCode.NonUniqueUsername);

            try
            {
                var user = _userRepository.Create(new User(account.Email, account.Username, account.Password, account.Name, account.Surname, account.City, account.Country, account.Phone, account.Profession, account.CompanyInformation, (UserRole)account.Role, account.IsActivated));
                return _tokenGenerator.GenerateAccessToken(user);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }
    }
}
