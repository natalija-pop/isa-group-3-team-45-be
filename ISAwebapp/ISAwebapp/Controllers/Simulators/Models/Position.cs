namespace API.Controllers.Simulators.Models
{
    public class Position
    {
        public double longitude { get; set; }
        public double latitude { get; set; }

        public Position()
        {
        }
        public Position(double longitude, double latitude)
        {
            this.longitude = longitude;
            this.latitude = latitude;
        }
    }
}