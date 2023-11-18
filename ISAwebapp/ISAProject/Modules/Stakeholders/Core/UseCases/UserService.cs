using AutoMapper;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.API.Public;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
