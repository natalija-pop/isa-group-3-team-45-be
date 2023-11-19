using AutoMapper;
using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace ISAProject.Modules.Stakeholders.Core.UseCases
{
    public class UserService : CrudService<UserDto, User>, IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(ICrudRepository<User> repository, IMapper mapper, IUserRepository userRepository) : base(repository, mapper)
        {
            _userRepository = userRepository;
        }

        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public bool Exists(string email)
        {
            return _userRepository.Exists(email);
        }

        public User? GetActiveUserByEmail(string email)
        {
            return _userRepository.GetActiveUserByEmail(email);
        }

        public Result<UserDto> AddNewCompanyAdmin(UserDto userDto, long companyId)
        {
            var user = Create(MapToDomain(userDto));
            _userRepository.Create(new CompanyAdmin(companyId, user.Id));
            return MapToDto(user);
        }
    }
}
