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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordGenerator _passwordGenerator;

        public AuthenticationService(ITokenGenerator tokenGenerator, IUserRepository userRepository, IPasswordGenerator passwordGenerator, IEmployeeRepository employeeRepository)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
            _passwordGenerator = passwordGenerator;
            _employeeRepository = employeeRepository;
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

        public Result<AuthenticationTokensDto> RegisterUser(EmployeeRegistrationDto account)
        {
            if (_userRepository.Exists(account.Email)) return Result.Fail(FailureCode.NonUniqueUsername);

            try
            {
                var user = _employeeRepository.Create(new Employee(account.City, account.Country, account.Phone, account.Profession, account.CompanyInformation, account.Email, 
                    account.Password, account.Name, account.Surname, UserRole.Employee, false));
                return _tokenGenerator.GenerateAccessToken(user);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<CredentialsDto> RegisterSysAdmin(AccountRegistrationDto account)
        {
            if (_userRepository.Exists(account.Email)) return Result.Fail(FailureCode.NonUniqueUsername);
            try
            {
                var password = _passwordGenerator.GeneratePassword();
                _userRepository.Create(new User(account.Email, password, account.Name, account.Surname, UserRole.SystemAdministrator, true));
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
