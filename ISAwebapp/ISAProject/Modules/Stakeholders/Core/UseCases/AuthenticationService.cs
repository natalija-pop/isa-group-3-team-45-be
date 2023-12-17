using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace ISAProject.Modules.Stakeholders.Core.UseCases
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordGenerator _passwordGenerator;

        public AuthenticationService(ITokenGenerator tokenGenerator, IUserRepository userRepository, IPasswordGenerator passwordGenerator)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
            _passwordGenerator = passwordGenerator;
        }

        public Result<AuthenticationTokensDto> Login(CredentialsDto credentials)
        {
            var user = _userRepository.GetActiveUserByEmail(credentials.Email);
            if (user == null || credentials.Password != user.Password || user.IsActivated == false) return Result.Fail(FailureCode.NotFound);
            if (user is { Role: UserRole.SystemAdministrator, ForcePasswordReset: true } ||
                user is { Role: UserRole.CompanyAdministrator, ForcePasswordReset: true})
                return Result.Ok( new AuthenticationTokensDto
                    {
                        Id = -1,
                        AccessToken = "ForcePasswordReset"
                    }
                );
            return _tokenGenerator.GenerateAccessToken(user);
        }

        public Result<AuthenticationTokensDto> RegisterUser(UserRegistrationDto account)
        {
            if (_userRepository.Exists(account.Email)) return Result.Fail(FailureCode.NonUniqueUsername);

            try
            {
                var user = _userRepository.Create(new User(account.Email, account.Password, account.Name, account.Surname, account.City, account.Country, account.Phone, account.Profession, account.CompanyInformation, account.Role, account.IsActivated));
                return _tokenGenerator.GenerateAccessToken(user);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<CredentialsDto> RegisterSysAdmin(SysAdminRegistrationDto account)
        {
            if (_userRepository.Exists(account.Email)) return Result.Fail(FailureCode.NonUniqueUsername);
            try
            {
                var password = _passwordGenerator.GeneratePassword();
                _userRepository.Create(new User(account.Email, password, account.Name, account.Surname, account.City, account.Country, account.Phone, account.Profession, account.CompanyInformation, UserRole.SystemAdministrator, true));
                return new CredentialsDto
                {
                    Email = account.Email,
                    Password = password
                };
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }
    }
}
