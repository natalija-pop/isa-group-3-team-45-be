namespace ISAProject.Modules.Company.API.Dtos
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EquipmentType Type { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto? Company { get; set; }
    }
}
