using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.Core.Domain;
namespace ISAProject.Modules.Stakeholders.API.Converters
{
    public static class CompanyAdminConverter
    {
        public static CompanyAdminDto ConvertToDto(CompanyAdmin admin)
        {
            return new CompanyAdminDto
            {
                Id = (int)admin.Id,  // Assuming there's an Id property in the Entity base class
                Email = admin.Email,
                Password = admin.Password,
                Name = admin.Name,
                Surname = admin.Surname,
                Role = admin.Role,
                IsActivated = admin.IsActivated,
                CompanyId = (int)admin.CompanyId 
            };
        }
        public static CompanyAdmin ConvertToDomain(CompanyAdminDto adminDto)
        {
            return new CompanyAdmin(
                adminDto.CompanyId,
                adminDto.Email,
                adminDto.Password,
                adminDto.Name,
                adminDto.Surname,
                adminDto.Role,
                adminDto.IsActivated
            );
        }
        public static List<CompanyAdminDto> ConvertToDto(List<CompanyAdmin> admins)
        {
            return admins.Select(ConvertToDto).ToList();
        }
        public static List<CompanyAdmin> ConvertToDomain(List<CompanyAdminDto> admins)
        {
            return admins.Select(ConvertToDomain).ToList();
        }
    }
}