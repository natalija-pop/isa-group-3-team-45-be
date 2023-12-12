namespace ISAProject.Modules.Company.API.Dtos
{
    public class AppointmentDto
    {
        public long Id { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurname { get; set; }
        public int CompanyId { get; set; }
    }
}
