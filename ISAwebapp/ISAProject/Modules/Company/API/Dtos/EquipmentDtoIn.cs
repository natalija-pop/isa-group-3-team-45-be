using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.API.Dtos
{
    public class EquipmentDtoIn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EquipmentType Type { get; set; }
        public int CompanyId { get; set; }
    }
}
