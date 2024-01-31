using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.Core.Domain;

namespace ISAProject.Modules.Stakeholders.API.Converters
{
    public static class UserConverter
    {
        public static UserDto ConvertToDto(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = (int)user.Id,  // Assuming there's an Id property in the Entity base class
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                Surname = user.Surname,
                Role = user.Role,
                IsActivated = user.IsActivated,
                PenaltyPoints = user.PenaltyPoints,
            };
        }

        public static User ConvertToDomain(UserDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }

            return new User(
                userDto.Email,
                userDto.Password,
                userDto.Name,
                userDto.Surname,
                userDto.Role,
                userDto.IsActivated
            );
        }

        public static List<UserDto> ConvertToDto(List<User> users)
        {
            return users.Select(ConvertToDto).ToList();
        }
        public static List<User> ConvertToDomain(List<UserDto> users)
        {
            return users.Select(ConvertToDomain).ToList();
        }
    }
}
