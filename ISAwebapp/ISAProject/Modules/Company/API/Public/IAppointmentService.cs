using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.API.Public
{
    public interface IAppointmentService
    {
        Result<AppointmentDto> Create(AppointmentDto appointmentDto);
        Result<AppointmentDto> Get(int id);
        Result<AppointmentDto> Update(AppointmentDto appointmentDto);
        Result<List<AppointmentDto>> GetAll();
    }
}
