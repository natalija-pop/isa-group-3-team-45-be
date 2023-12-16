using ISAProject.Configuration.Core.Domain;
using ISAProject.Modules.Company.API;

namespace ISAProject.Modules.Company.Core.Domain
{
    public class Equipment: Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public EquipmentType Type { get; private set; }
        public int Quantity { get; private set; }
        public int ReservedQuantity { get; private set; }
        public long CompanyId { get; set; }

        public Equipment() {}

        public Equipment(string name, string description, EquipmentType type, int quantity, long companyId)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            ReservedQuantity = 0;
            Type = type;
            CompanyId = companyId;
        }
    }
}
