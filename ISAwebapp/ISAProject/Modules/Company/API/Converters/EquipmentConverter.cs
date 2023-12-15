using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.API.Converters
{
    public static class EquipmentConverter
    {
        public static EquipmentDto ToDto(this Equipment equipment)
        {
            if (equipment == null) return null;
            return new EquipmentDto
            {
                Id = (int)equipment.Id,
                Name = equipment.Name,
                Description = equipment.Description,
                Type = equipment.Type,
                CompanyId = (int)equipment.CompanyId
            };
        }
    }
}
