using ISAProject.Configuration.Core.Domain;
using ISAProject.Modules.Company.API;

namespace ISAProject.Modules.Company.Core.Domain
{
    public class Equipment: Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public EquipmentType Type { get; private set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public Equipment() {}
        
        public Equipment(string name, string description, EquipmentType type, Company company)
        {
            Name = name;
            Description = description;
            Type = type;
            Company = company;
            CompanyId = company.Id;
        }
    }
}
