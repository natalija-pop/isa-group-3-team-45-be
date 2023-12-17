using ISAProject.Configuration.Core.Domain;

namespace ISAProject.Modules.Company.Core.Domain
{
    public class Address : ValueObject
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Address()
        {
        }

        [Newtonsoft.Json.JsonConstructor]
        public Address(string street, int number, string city, string country, double latitude, double longitude)
        {
            Validate(street, number, city, country, latitude, longitude);
            Street = street;
            Number = number;
            City = city;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return Number;
            yield return City;
            yield return Country;
            yield return Latitude;
            yield return Longitude;
        }

        private static void Validate(string street, int number, string city, string country, double latitude, double longitude)
        {
            if (street == null || street.Equals("")) throw new ArgumentException("Exception! Street is emtpy!");
            if (city == null || city.Equals("")) throw new ArgumentException("Exception! City is emtpy!");
            if (country == null || country.Equals("")) throw new ArgumentException("Exception! Country is emtpy!");
            if (number < 1) throw new ArgumentException("Exception! Number cannot be 0 or negative!");
            if (Math.Abs(latitude) > 90)
                throw new ArgumentException("Invalid Latitude.");
            if (Math.Abs(longitude) > 180)
                throw new ArgumentException("Invalid Longitude.");
        }

    }
}
