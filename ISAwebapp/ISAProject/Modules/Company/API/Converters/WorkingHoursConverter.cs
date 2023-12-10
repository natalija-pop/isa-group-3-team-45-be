using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.Core.Domain;

namespace ISAProject.Modules.Company.API.Converters
{
    public static class WorkingHoursConverter
    {
        public static WorkingHoursDto ToDto(this WorkingHours workingHours)
        {
            if (workingHours == null) return null;
            return new WorkingHoursDto
            {
                OpeningHours = workingHours.OpeningHours.ToString(),
                ClosingHours = workingHours.ClosingHours.ToString(),
                Weekends = workingHours.Weekends
            };
        }

        public static WorkingHours ToDomain(this WorkingHoursDto workingHoursDto)
        {
            if (workingHoursDto == null) return null;
            var openings = workingHoursDto.OpeningHours.Split(":");
            var closings = workingHoursDto.ClosingHours.Split(":");
            if (openings.Length < 3 || closings.Length < 3) return null;
            
            var openingHours = Convert.ToInt32(openings[0]);
            var openingMinutes = Convert.ToInt32(openings[1]);
            var openingSeconds = Convert.ToInt32(openings[2]);
            var openingTime = new TimeSpan(openingHours, openingMinutes, openingSeconds);
            
            var closingHours = Convert.ToInt32(closings[0]);
            var closingMinutes = Convert.ToInt32(closings[1]);
            var closingSeconds = Convert.ToInt32(closings[2]);
            var closingTime = new TimeSpan(closingHours, closingMinutes, closingSeconds);

            return new WorkingHours(openingTime, closingTime, workingHoursDto.Weekends);
        }
    }
}
