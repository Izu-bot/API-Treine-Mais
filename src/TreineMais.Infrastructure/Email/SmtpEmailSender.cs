using System;
using System.Net;
using System.Net.Mail;
using TreineMais.Application.Abstractions;

namespace TreineMais.Infrastructure.Email;

public class SmtpEmailSender : IEmailSender
{
    public async Task SendAsync(string to, string subject, string body)
    {
        var message = new MailMessage("kauanmartins977@gmail.com", to)
        {
            Subject = subject,
            Body = body
        };
        
        using var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(
                Environment.GetEnvironmentVariable("SMPT_USER"),
                Environment.GetEnvironmentVariable("SMPT_PASS")
            ),
            Timeout = 10000
        };
        await client.SendMailAsync(message);
    }
}
