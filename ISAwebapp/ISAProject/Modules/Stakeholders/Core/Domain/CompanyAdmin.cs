using ISAProject.Configuration.Core.Domain;

namespace ISAProject.Modules.Stakeholders.Core.Domain
{
    public class CompanyAdmin: Entity
    {
        public long CompanyId { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        
        public CompanyAdmin() {}

        public CompanyAdmin(long companyId, User user)
        {
            Validate(companyId);
            CompanyId = companyId;
            User = user;
            UserId = user.Id;
        }

        private static void Validate(long companyId)
        {
            if (companyId < 1) throw new ArgumentException("Exception! UserId cannot be less than 1");
        }
    }
}
