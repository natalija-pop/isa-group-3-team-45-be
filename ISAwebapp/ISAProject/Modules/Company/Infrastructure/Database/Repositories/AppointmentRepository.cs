﻿using ISAProject.Modules.Company.Core.Domain;
using ISAProject.Modules.Company.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Company.Infrastructure.Database.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly CompanyContext _context;

        public AppointmentRepository(CompanyContext companyContext)
        {
            _context = companyContext;
        }

        public Appointment Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public Appointment Get(long id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null) throw new KeyNotFoundException("Appointment not found.");
            return appointment;
        }

        public List<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public Appointment Update(Appointment appointment)
        {
            try
            {
                _context.Update(appointment);
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }
            return appointment;
        }
    }
}