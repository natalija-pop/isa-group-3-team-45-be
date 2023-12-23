
namespace ISAProject.Modules.Stakeholders.Core.Domain
{
    public class CompanyAdmin: User
    {
        public long? CompanyId { get; set; }
        
        public CompanyAdmin() {}

        public CompanyAdmin(long? companyId)
        {
            CompanyId = companyId;
        }
    }
}
