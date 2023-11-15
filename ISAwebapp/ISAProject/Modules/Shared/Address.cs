using ISAProject.Configuration.Core.Domain;

namespace ISAProject.Modules.Shared
{
    public class Address : ValueObject
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        [Newtonsoft.Json.JsonConstructor]
        public Address(string street, int number, string city, string country)
        {
            Validate(street, number, city, country);
            Street = street;
            Number = number;
            City = city;
            Country = country;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return Number;
            yield return City;
            yield return Country;
        }

        private static void Validate(string street, int number, string city, string country)
        {
            if (street == null || street.Equals("")) throw new ArgumentException("Exception! Street is emtpy!");
            if (city == null || city.Equals("")) throw new ArgumentException("Exception! City is emtpy!");
            if (country == null || country.Equals("")) throw new ArgumentException("Exception! Country is emtpy!");
            if (number < 1) throw new ArgumentException("Exception! Number cannot be 0 or negative!");
        }

    }
}
