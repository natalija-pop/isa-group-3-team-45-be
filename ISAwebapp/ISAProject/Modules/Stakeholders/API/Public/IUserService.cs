﻿using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Stakeholders.API.Dtos;

namespace ISAProject.Modules.Stakeholders.API.Public
{
    public interface IUserService
    {
        Result<UserDto> Create(UserDto userDto);
        Result<UserDto> Get(int id);
        Result<UserDto> Update(UserDto userDto);
        Result Delete(int id);
        Result<PagedResult<UserDto>> GetPaged(int page, int pageSize);
        Result<UserDto> AddNewCompanyAdmin(UserDto userDto, long companyId);
        Result<List<UserDto>> GetCompanyAdmins(long companyId);
        Result<bool> ChangePassword(PasswordChangeDto passwordChange);
    }
}
