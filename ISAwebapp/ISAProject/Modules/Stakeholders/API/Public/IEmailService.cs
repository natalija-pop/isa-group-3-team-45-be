using ISAProject.Modules.Company.API.Dtos;

namespace ISAProject.Modules.Stakeholders.API.Public
{
    public interface IEmailService
    {
        void SendActivationEmail(string recipientEmail, string activationLink);
        void SendRegistrationInfoEmail(string recipientEmail, string recipientGeneratedPassword);
        void SendAppointmentConfirmation(AppointmentDto appointment, string userEmail);
    }
}
