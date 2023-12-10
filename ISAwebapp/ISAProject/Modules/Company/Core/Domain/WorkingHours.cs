using ISAProject.Configuration.Core.Domain;

namespace ISAProject.Modules.Company.Core.Domain
{
    public class WorkingHours: ValueObject
    {
        //God doesn't work on Sundays neither do Companies
        public TimeSpan OpeningHours { get; init; }
        public TimeSpan ClosingHours { get; init; }
        public bool Weekends { get; init; } //Means Saturday

        public WorkingHours(TimeSpan openingHours, TimeSpan closingHours, bool weekends)
        {
            if(closingHours < openingHours) throw new ArgumentOutOfRangeException("Exception! Closing hours shouldn't be less than opening hours!");
            OpeningHours = openingHours;
            ClosingHours = closingHours;
            Weekends = weekends;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return OpeningHours;
            yield return ClosingHours;
            yield return Weekends;
        }
    }
}
