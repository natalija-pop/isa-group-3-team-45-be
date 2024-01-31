
namespace ISAProject.Modules.Stakeholders.Core.Domain
{
    public class CompanyAdmin: User
    {
        public long? CompanyId { get; set; }
        
        public CompanyAdmin() {}

        public CompanyAdmin(long? companyId, string email, string password, string name, string surname, UserRole role, bool isActivated) : base(email, password, name, surname, role, isActivated)
        {
            CompanyId = companyId;
        }
    }
}
