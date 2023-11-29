using System.Net.Mail;
using System.Net;
using System.Text;
using ISAProject.Modules.Stakeholders.API.Public;

namespace ISAProject.Modules.Stakeholders.Core.UseCases
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _port = 587;
        private readonly string _email = "anja1107.am@gmail.com";
        private readonly string _password = "gorblechbsniujnn";

        public void SendActivationEmail(string recipientEmail, string activationLink)
        {
            string link = $"http://localhost:4200/activate?token={activationLink}";
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_email);
                mail.To.Add(recipientEmail);
                mail.Subject = "Aktivacija naloga";
                mail.Body = $"Kliknite na ovaj link da biste aktivirali nalog: {link}";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(_smtpServer, _port))
                {
                    smtp.Credentials = new NetworkCredential(_email, _password);
                    smtp.EnableSsl = true;
                    try
                    {
                        smtp.Send(mail);
                        Console.WriteLine("Mejl je uspesno poslat!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Doslo je do greske prilikom slanja mejla: " + ex.Message);
                    }
                }
            }
        }

        public void SendRegistrationInfoEmail(string recipientEmail, string recipientGeneratedPassword)
        {
            var mailBodyBuilder = new StringBuilder("Poštovani,<br><br>");
            mailBodyBuilder.Append("Vaši kredencijali za logovanje su:<br>");
            mailBodyBuilder.Append($"Korisničko ime:{recipientEmail}<br>" +
                                   $"Lozinka: {recipientGeneratedPassword}<br><br>");
            mailBodyBuilder.Append("Molimo Vas da promenite datu lozinku prilikom prvog prijavljivanja na sistem.");
            var emailBody = mailBodyBuilder.ToString();
            var emailSubject = "Uspešna registracija naloga";

            SendEmail(recipientEmail, emailSubject, emailBody);
        }

        private void SendEmail(string recipientEmail, string emailSubject, string emailBody)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_email);
                mail.To.Add(recipientEmail);
                mail.Subject = emailSubject;
                mail.Body = emailBody;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(_smtpServer, _port))
                {
                    smtp.Credentials = new NetworkCredential(_email, _password);
                    smtp.EnableSsl = true;
                    try
                    {
                        smtp.Send(mail);
                        Console.WriteLine("Email successfully sent!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
