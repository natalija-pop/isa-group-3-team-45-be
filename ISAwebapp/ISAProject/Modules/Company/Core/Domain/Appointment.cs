using ISAProject.Configuration.Core.Domain;

namespace ISAProject.Modules.Company.Core.Domain
{
    public class Appointment: Entity
    {
        //Duration in minutes
        private readonly int _duration = 30;
        public DateTime Start { get; init; }
        public int Duration
        {
            get => _duration;
        }

        public string AdminName { get;  set; }
        public string AdminSurname { get;  set; }
        public string? CustomerName { get; set; } = null;
        public string? CustomerSurname { get; set; } = null;
        public long CompanyId { get; init; }

        public Appointment()
        {
            
        }
        public Appointment(DateTime start, string adminName, string adminSurname, string? customerName, string? customerSurname, int companyId)
        {
            Start = start;
            AdminName = adminName;
            AdminSurname = adminSurname;
            CustomerName = customerName;
            CustomerSurname = customerSurname;
            CompanyId = companyId;
        }
    }
}
