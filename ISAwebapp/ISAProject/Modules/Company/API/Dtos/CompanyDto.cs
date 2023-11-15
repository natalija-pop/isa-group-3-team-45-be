using ISAProject.Modules.Company.Core.Domain;

namespace ISAProject.Modules.Company.API.Dtos
{
    public class CompanyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
    }
}
