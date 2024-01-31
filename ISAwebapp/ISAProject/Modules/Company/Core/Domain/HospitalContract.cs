using ISAProject.Configuration.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.Core.Domain
{
    public class HospitalContract : Entity
    {
        public string Equipment { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryTime { get; set; }
        public string HospitalName { get; set; }
        public string HospitalAddress { get; set; }

        public HospitalContract()
        {
        }

        public HospitalContract(string equipment, int quantity, DateTime deliveryTime, string hospitalName, string hospitalAddress)
        {
            Equipment = equipment;
            Quantity = quantity;
            DeliveryTime = deliveryTime;
            HospitalName = hospitalName;
            HospitalAddress = hospitalAddress;
        }
    }
}
