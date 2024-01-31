namespace API.Controllers.Simulators.Models
{
    public class ActivationMessage
    {
        public Position StartPoint { get; set; }
        public Position EndPoint { get; set; }
        public int Frequency { get; set; }

        public ActivationMessage()
        {
        }

        public ActivationMessage(Position startPoint, Position endPoint, int frequency)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Frequency = frequency;
        }
    }
}