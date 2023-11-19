using ISAProject.Configuration.Core.Domain;

namespace ISAProject.Modules.Stakeholders.Core.Domain
{
    public class CompanyAdmin: Entity
    {
        
        public long CompanyId { get; set; }
        public long UserId { get; set; }
        
        public CompanyAdmin() {}

        public CompanyAdmin(long companyId, long userId)
        {
            Validate(userId, companyId);
            CompanyId = companyId;
            UserId = userId;
        }

        private static void Validate(long userId, long companyId)
        {
            if (userId < 1) throw new ArgumentException("Exception! UserId cannot be less than 1");
            if (companyId < 1) throw new ArgumentException("Exception! UserId cannot be less than 1");
        }
    }
}
