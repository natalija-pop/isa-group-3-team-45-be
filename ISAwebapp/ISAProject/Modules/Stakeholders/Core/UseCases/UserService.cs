using AutoMapper;
using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Stakeholders.API.Converters;
using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace ISAProject.Modules.Stakeholders.Core.UseCases
{
    public class UserService : CrudService<UserDto, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyAdminRepo _companyAdminsRepository;

        public UserService(ICrudRepository<User> repository, IMapper mapper, IUserRepository userRepository, ICompanyAdminRepo companyAdminRepository) : base(repository, mapper)
        {
            _userRepository = userRepository;
            _companyAdminsRepository = companyAdminRepository;
        }

        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public bool Exists(string email)
        {
            return _userRepository.Exists(email);
        }

        public Result<CompanyAdminDto> GetCompanyAdmin(int companyAdminId)
        {
            var admin = _companyAdminsRepository.GetCompanyAdmin(companyAdminId);
            if (admin == null) return Result.Fail(FailureCode.NotFound);
            return CompanyAdminConverter.ConvertToDto(admin);
        }

        public User? GetActiveUserByEmail(string email)
        {
            return _userRepository.GetActiveUserByEmail(email);
        }
        public Result<bool> ChangePassword(PasswordChangeDto passwordChange)
        {
            var user = _userRepository.GetActiveUserByEmail(passwordChange.Email);
            if (user == null || passwordChange.OldPassword != user.Password || user.IsActivated == false) return Result.Fail(FailureCode.NotFound);
            if (!user.ChangePassword(passwordChange.NewPassword)) return false;
            CrudRepository.Update(user);
            return true;
        }

        public async Task ClearPenaltyPointsForAllUsers()
        {
            DateTime currentDate = DateTime.Now;

            if (currentDate.Day == 1)
            {
                var users = _userRepository.GetAll();

                foreach (var user in users)
                {
                    user.PenaltyPoints = 0;
                    CrudRepository.Update(user);
                }
            }
        }

    }
}
