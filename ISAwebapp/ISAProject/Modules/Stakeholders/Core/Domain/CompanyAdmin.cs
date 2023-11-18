using System.ComponentModel.DataAnnotations.Schema;
using ISAProject.Configuration.Core.Domain;

namespace ISAProject.Modules.Stakeholders.Core.Domain
{
    public class CompanyAdmin: Entity
    {
        public long CompanyId { get; set; }

        [NotMapped]
        public Company.Core.Domain.Company Company { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        
        public CompanyAdmin() {}

        public CompanyAdmin(long userId, Company.Core.Domain.Company company)
        {
            Validate(userId, company.Id);
            UserId = userId;
            Company = company;
            CompanyId = company.Id;
        }

        private static void Validate(long userId, long companyId)
        {
            if (userId < 1) throw new ArgumentException("Exception! UserId cannot be less than 1");
            if (companyId < 1) throw new ArgumentException("Exception! UserId cannot be less than 1");
        }
    }
}
