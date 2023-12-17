using AutoMapper;
using FluentResults;
using ISAProject.Configuration.Core.UseCases;
using ISAProject.Modules.Company.API.Dtos;
using ISAProject.Modules.Company.API.Public;
using ISAProject.Modules.Company.Core.Domain;
using ISAProject.Modules.Company.Core.Domain.RepositoryInterfaces;
using ISAProject.Modules.Stakeholders.Core.Domain;
using ISAProject.Modules.Stakeholders.Core.Domain.RepositoryInterfaces;


namespace ISAProject.Modules.Company.Core.UseCases
{
    public class AppointmentService: MappingService<AppointmentDto, Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        private readonly ICompanyAdminRepo _companyAdminRepo;
        public AppointmentService(IMapper mapper, IAppointmentRepository repository, ICompanyAdminRepo companyRepo) : base(mapper)
        {
            _repository = repository;
            _companyAdminRepo = companyRepo;
        }
        public Result<AppointmentDto> Create(AppointmentDto appointmentDto)
        {
            var result = _repository.Create(MapToDomain(appointmentDto));

            return MapToDto(result);

        }

        public Result<AppointmentDto> Get(int id)
        {
            var encounter = _repository.Get(id);
            return MapToDto(encounter);

        }
        public Result<AppointmentDto> Update(AppointmentDto appointmentDto)
        {
            try
            {
                var result = _repository.Update(MapToDomain(appointmentDto));
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }

        }
        public Result<List<AppointmentDto>> GetAll()
        {
            var encounters = _repository.GetAll();
            return MapToDto(encounters);
        }
        
        private Company.Core.Domain.Company GetAppointmentsCompany(int id)
        {
            var company = _repository.GetAppointmentsCompany(id);
            return company;
        }

        public Result<List<Appointment>> GenerateRecommendedAppointments(DateTime selectedDate, int companyId)
        {
            var allAppointments = GetAll().Value;

            var company = GetAppointmentsCompany(companyId);

            var openingHours = company.WorkingHours.OpeningHours;
            var closingHours = company.WorkingHours.ClosingHours;

            var existingAppointments = allAppointments
                .Where(a => a.Start.Date == selectedDate.Date &&
                            a.Start.TimeOfDay >= openingHours &&
                            a.Start.TimeOfDay < closingHours)
                .ToList();

            var administrators = _companyAdminRepo.GetCompanyAdmins(companyId);

            var recommendedAppointments = new List<Appointment>();

            DateTime currentTime = selectedDate.Date.Add(openingHours);
            DateTime endTime = selectedDate.Date.Add(closingHours);

            while (currentTime.AddMinutes(existingAppointments.First().Duration) <= endTime)
            {
                User availableAdmin = FindAvailableAdministrator(administrators, existingAppointments, currentTime);
                if (availableAdmin != null) 
                {
                    var recommendedAppointment = new Appointment
                    {
                        Start = currentTime,
                        AdminName = availableAdmin.Name,
                        AdminSurname = availableAdmin.Surname,
                        CustomerName = "",
                        CustomerSurname = "",
                        CompanyId = companyId,
                    };

                    recommendedAppointments.Add(recommendedAppointment);
                }

                currentTime = currentTime.AddMinutes(existingAppointments.First().Duration);
            }

            return recommendedAppointments;
        }

        private User FindAvailableAdministrator(List <User> administrators, List<AppointmentDto> existingAppointments, DateTime currentTime)
        {
            foreach (var admin in administrators)
            {
                bool hasAppointment = false;

                foreach(var appointment in existingAppointments)
                {
                    if (appointment.Start.Ticks <= currentTime.Ticks && 
                        appointment.Start.AddMinutes(appointment.Duration) > currentTime &&
                        appointment.AdminName == admin.Name &&
                        appointment.AdminSurname == admin.Surname)
                    {
                        hasAppointment = true;
                        break;
                    }
                }

                if (!hasAppointment)
                {
                    return admin;
                }

            }
            return null;
        }

        public bool IsAppointmentValid (DateTime selectedDate, int companyId, string adminName, string adminSurname)
        {
            var allAppointments = GetAll().Value;
            bool isAppointmentValid = !allAppointments.Any(appointment =>
                 appointment.CompanyId == companyId &&
                 appointment.AdminName == adminName &&
                 appointment.AdminSurname == adminSurname &&
                 appointment.Start <= selectedDate &&
                 selectedDate < appointment.Start.AddMinutes(appointment.Duration));

            return isAppointmentValid;

        }

        public Result<List<AppointmentDto>> GetCompanyAppointments(int companyId)
        {
            var appointments = _repository.GetCompanyAppointments(companyId);
            return MapToDto(appointments);
        }

    }
}
