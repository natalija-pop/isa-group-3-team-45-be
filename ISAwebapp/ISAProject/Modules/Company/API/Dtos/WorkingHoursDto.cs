namespace ISAProject.Modules.Company.API.Dtos
{
    public class WorkingHoursDto
    {
        public TimeSpan OpeningHours { get; set; }
        public TimeSpan ClosingHours { get; set; }
        public bool Weekends { get; set; }
    }
}
