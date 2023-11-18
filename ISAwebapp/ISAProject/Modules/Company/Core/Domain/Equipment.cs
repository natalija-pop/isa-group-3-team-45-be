using System.ComponentModel.DataAnnotations.Schema;
using ISAProject.Configuration.Core.Domain;
using ISAProject.Modules.Company.API;

namespace ISAProject.Modules.Company.Core.Domain
{
    public class Equipment: Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public EquipmentType Type { get; private set; }
        
        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public Company Company { get; private set; }

        public Equipment(string name, string description, Company company, EquipmentType type)
        {
            Name = name;
            Description = description;
            Company = company;
            Type = type;
        }
    }
}
