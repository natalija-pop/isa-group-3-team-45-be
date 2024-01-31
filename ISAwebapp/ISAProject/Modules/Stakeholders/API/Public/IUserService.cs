using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Stakeholders.API.Dtos;
using ISAProject.Modules.Stakeholders.Core.Domain;

namespace ISAProject.Modules.Stakeholders.API.Public
{
    public interface IUserService
    {
        Result<UserDto> Create(UserDto userDto);
        Result<UserDto> Get(int id);
        Result<CompanyAdminDto> GetCompanyAdmin(int companyAdminId);
        Result<UserDto> Update(UserDto userDto);
        void AddCancelationPenalty(long? userId, DateTime start);
        Result Delete(int id);
        Result<PagedResult<UserDto>> GetPaged(int page, int pageSize);
        Result<bool> ChangePassword(PasswordChangeDto passwordChange);
        Result<List<UserDto>> GetUsersByIds(List<long> userIds);
        bool HasDeletionPenaltyInCurrentMonth(long userId, DateTime todaysDate);

        Result<User> ClearPenaltyPointsForUser(int userId);

    }
}
