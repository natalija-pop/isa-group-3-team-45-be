using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.API.Dtos
{
    public class AppointmentValidationDto
    {
        public DateTime Date { get; set; }
        public int CompanyId { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
    }
}
