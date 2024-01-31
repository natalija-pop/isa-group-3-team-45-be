using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.API.Dtos
{
    public class HospitalContractDto
    {
        public string Equipment { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryTime { get; set; }
        public string HospitalName { get; set; }
        public string HospitalAddress { get; set; }
    }
}
