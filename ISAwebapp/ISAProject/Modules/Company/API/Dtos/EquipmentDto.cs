namespace ISAProject.Modules.Company.API.Dtos
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int ReservedQuantity { get; set; }   
        public EquipmentType Type { get; set; }
        public int CompanyId { get; set; }
        public double Price { get; set; }

    }
}
