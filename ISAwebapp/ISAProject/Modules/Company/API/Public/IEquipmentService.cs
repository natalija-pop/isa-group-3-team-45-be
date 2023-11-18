﻿using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Dtos;

namespace ISAProject.Modules.Company.API.Public
{
    public interface IEquipmentService
    {
        Result<EquipmentDto> Get(int id);
        Result<PagedResult<EquipmentDto>> GetPaged(int page, int pageSize);
        Result<List<EquipmentDto>> Search(string searchKeyword);
    }
}

