using SpaceMission2026.Core.Models;

namespace SpaceMission2026.Services.Notifications.Contracts;

/// <summary>
/// Defines the contract for dispatching mission reports to Mission Control.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Sends an email report detailing the outcome of each astronaut's journey.
    /// </summary>
    /// <param name="smtpHost">The SMTP server host address.</param>
    /// <param name="smtpPort">The SMTP server port.</param>
    /// <param name="senderEmail">The email address used to authenticate and send the email.</param>
    /// <param name="password">The password or app-specific password for the sender's email.</param>
    /// <param name="receiverEmail">The destination email address.</param>
    /// <param name="astronauts">The list of astronauts with their mission status.</param>
    void SendReport(string smtpHost, int smtpPort, string senderEmail, string password, string receiverEmail, IEnumerable<Astronaut> astronauts);
}