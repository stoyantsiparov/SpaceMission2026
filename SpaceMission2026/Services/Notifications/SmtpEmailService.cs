using System.Net;
using System.Net.Mail;
using System.Text;
using SpaceMission2026.Common;
using SpaceMission2026.Core.Models;
using SpaceMission2026.Services.Notifications.Contracts;

namespace SpaceMission2026.Services.Notifications;

public class SmtpEmailService : IEmailService
{
    /// <inheritdoc />
    public void SendReport(string smtpHost, int smtpPort, string senderEmail, string password, string receiverEmail, IEnumerable<Astronaut> astronauts)
    {
        try
        {
            var sb = new StringBuilder();
            sb.AppendLine(AppMessages.EmailReportTitle);
            sb.AppendLine(new string('-', 30));

            foreach (var astronaut in astronauts.OrderByDescending(a => a.IsRescued).ThenBy(a => a.TotalPathCost))
            {
                string note = astronaut.IsRescued
                    ? string.Format(AppMessages.EmailRescuedNote, astronaut.Id, astronaut.TotalPathCost)
                    : string.Format(AppMessages.EmailLostNote, astronaut.Id);

                sb.AppendLine(note);
            }

            using var client = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(senderEmail, password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail),
                Subject = AppMessages.EmailSubject,
                Body = sb.ToString(),
                IsBodyHtml = false
            };

            mailMessage.To.Add(receiverEmail);
            client.Send(mailMessage);

            Console.WriteLine(AppMessages.EmailSentSuccess);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format(AppMessages.EmailWarning, ex.Message));
        }
    }
}