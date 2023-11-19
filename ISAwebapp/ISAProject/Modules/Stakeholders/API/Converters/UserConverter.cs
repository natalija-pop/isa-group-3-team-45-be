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
                City = user.City,
                Country = user.Country,
                Phone = user.Phone,
                Profession = user.Profession,
                CompanyInformation = user.CompanyInformation,
                Role = user.Role,
                IsActivated = user.IsActivated
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
                userDto.City,
                userDto.Country,
                userDto.Phone,
                userDto.Profession,
                userDto.CompanyInformation,
                userDto.Role,
                userDto.IsActivated
            );
        }
    }
}
