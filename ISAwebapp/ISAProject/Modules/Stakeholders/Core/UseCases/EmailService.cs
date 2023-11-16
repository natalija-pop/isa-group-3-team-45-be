using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ISAProject.Modules.Stakeholders.API.Public;

namespace ISAProject.Modules.Stakeholders.Core.UseCases
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailService()
        {
            // Ovde bi trebalo da dobijete ove informacije iz konfiguracije
            _smtpServer = "smtp.gmail.com";
            _smtpPort = 587; // Port za SMTP server (obično je 587 ili 465 za SSL)
            _smtpUsername = "anja1107.am@gmail.com";
            _smtpPassword = "anjanjaa.01";
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(_smtpUsername);
                    mailMessage.To.Add(toEmail);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true; // Postavite na true ako je sadržaj HTML

                    using (SmtpClient smtpClient = new SmtpClient(_smtpServer, _smtpPort))
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                        smtpClient.EnableSsl = true; // Postavite na true ako koristite SSL

                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                // Obrada greške prilikom slanja emaila
                Console.WriteLine("Greška prilikom slanja emaila: " + ex.Message);
                throw;
            }
        }
    }
}
