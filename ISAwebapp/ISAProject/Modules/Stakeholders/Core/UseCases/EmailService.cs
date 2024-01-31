using System.Net.Mail;
using System.Net;
using System.Text;
using ISAProject.Modules.Stakeholders.API.Public;
using IronBarCode;
using ISAProject.Modules.Company.API.Dtos;

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
            mailBodyBuilder.Append("Vaši kredencijali za logovanje su:<br><br>");
            mailBodyBuilder.Append($"Korisničko ime:{recipientEmail}<br>" +
                                   $"Lozinka: {recipientGeneratedPassword}<br><br>");
            mailBodyBuilder.Append("Molimo Vas da promenite datu lozinku prilikom prvog prijavljivanja na sistem.");
            var emailBody = mailBodyBuilder.ToString();
            var emailSubject = "Uspešna registracija naloga";

            SendEmail(recipientEmail, emailSubject, emailBody);
        }

        public void SendProcessedAppointmentConfirmation(AppointmentDto appointment, string userEmail)
        {
            var mailBodyBuilder = new StringBuilder("Poštovani,<br><br>");
            mailBodyBuilder.Append("Želimo se iskreno zahvaliti na uspešno završenoj rezervaciji opreme putem naše aplikacije.<br><br>");
            mailBodyBuilder.Append($"Ime:{appointment.CustomerName}<br>" +
                                   $"Prezime: {appointment.CustomerSurname}<br>");
            mailBodyBuilder.Append($"Datum i vreme rezervacije: {appointment.Start} <br>");
            mailBodyBuilder.Append($"Preuzeta oprema: <br>");
            foreach (var equipment in appointment.Equipment)
            {
                mailBodyBuilder.Append($" - {equipment.Name}<br>");
            }
            mailBodyBuilder.Append("<br><br>");
            mailBodyBuilder.Append("Hvala Vam još jednom na poverenju. Nadamo se da smo ispunili Vaša očekivanja.");
            var emailBody = mailBodyBuilder.ToString();
            var emailSubject = "Uspešno preuzimanje rezervacije";

            SendEmail(userEmail, emailSubject, emailBody);
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

        public void SendAppointmentConfirmation(AppointmentDto appointment, string recipientEmail)
        {
            StringBuilder appointmentDetailsBuilder = new StringBuilder($"AppointmentEAN: {appointment.Id}\n");
            appointmentDetailsBuilder.Append($"Start: {appointment.Start}\n");
            appointmentDetailsBuilder.Append("Equipment:\n");
            foreach (var equipment in appointment.Equipment)
            {
                appointmentDetailsBuilder.Append($"{equipment.Name}\n");
            }
            appointmentDetailsBuilder.Append($"Admin: {appointment.AdminName} {appointment.AdminSurname}\n");
            appointmentDetailsBuilder.Append($"Customer: {appointment.CustomerName} {appointment.CustomerSurname}\n");

            var barcodeFilePath = GenerateQrCode(appointment, recipientEmail, appointmentDetailsBuilder);
            SendEmailWithAttachment(recipientEmail, "Reservation confirmation", "Reservation details are in attachment", barcodeFilePath);

        }

        private string GenerateQrCode(AppointmentDto appointment, string recipientEmail, StringBuilder appointmentDetailsBuilder)
        {
            string barcodeFolderPath = "BarCodes";
            try
            {
                if (!Directory.Exists(barcodeFolderPath))
                {
                    Directory.CreateDirectory(barcodeFolderPath);
                }

                string barcodeFileName = $"{appointment.CustomerId}_{appointment.Id}.png";
                string barcodeFilePath = Path.Combine(barcodeFolderPath, barcodeFileName);

                GeneratedBarcode qrcode = IronBarCode.BarcodeWriter.CreateBarcode(appointmentDetailsBuilder.ToString(), BarcodeEncoding.QRCode);
                qrcode.SaveAsPng(barcodeFilePath);
                return barcodeFilePath;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving barcode image: {ex.Message}");
            }
        }

        private void SendEmailWithAttachment(string recipientEmail, string emailSubject, string emailBody, string attachmentPath)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_email);
                mail.To.Add(recipientEmail);
                mail.Subject = emailSubject;
                mail.Body = emailBody;
                mail.IsBodyHtml = true;

                Attachment attachment = new Attachment(attachmentPath, "image/png");
                mail.Attachments.Add(attachment);

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
