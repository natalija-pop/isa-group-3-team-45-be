using ISAProject.Configuration.Core.Domain;

namespace ISAProject.Modules.Company.Core.Domain
{
    public class Appointment: Entity
    {
        //Duration in minutes
        private readonly int _duration = 60;
        public DateTime Start { get; init; }
        public int Duration
        {
            get => _duration;
        }
        public long AdminId { get; init; }
        public string AdminName { get;  init; }
        public string AdminSurname { get;  init; }
        public long? CustomerId { get; set; }
        public string? CustomerName { get; set; } = null;
        public string? CustomerSurname { get; set; } = null;
        public long CompanyId { get; init; }
        public AppointmentStatus Status { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }

        public Appointment()
        {
        }

        public Appointment(DateTime start, string adminName, string adminSurname, string? customerName, string? customerSurname, long companyId, long adminId, long? customerId)
        {
            Start = start;
            AdminId = adminId;
            CustomerId = customerId;
            AdminName = adminName;
            AdminSurname = adminSurname;
            CustomerName = customerName;
            CustomerSurname = customerSurname;
            CompanyId = companyId;
            Status = AppointmentStatus.Predefined;
        }

        public bool IsAvailableForReservation()
        {
            return CustomerId == null || CustomerId == 0;
        }

        public enum AppointmentStatus
        {
            Predefined,
            Scheduled,
            Canceled,
            Processed
        }
    }
}
