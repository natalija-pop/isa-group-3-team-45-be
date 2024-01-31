namespace API.Controllers.Simulators.Models
{
    public class Contract
    {
        public string Equipment { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryTime { get; set; }
        public string HospitalName { get; set; }
        public string HospitalAddress{ get; set; }

        public Contract()
        {
        }

        public Contract(string equipment, int quantity, DateTime deliveryTime, string hospitalName, string hospitalAddress)
        {
            Equipment = equipment;
            Quantity = quantity;
            DeliveryTime = deliveryTime;
            HospitalName = hospitalName;
            HospitalAddress = hospitalAddress;
        }
    }
}
