using ISAProject.Modules.Company.Core.Domain;
using ISAProject.Modules.Stakeholders.API.Dtos;
using static ISAProject.Modules.Company.Core.Domain.Appointment;

namespace ISAProject.Modules.Company.API.Dtos
{
    public class AppointmentDto
    {
        public long Id { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public long AdminId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurname { get; set; }
        public long? CustomerId { get; set; }
        public int CompanyId { get; set; }
        public AppointmentStatus Status { get; set; }
        public ICollection<EquipmentDto>? Equipment { get; set; }
    }
}
