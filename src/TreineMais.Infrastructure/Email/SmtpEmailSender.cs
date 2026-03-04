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
            Credentials = new NetworkCredential(
                userName: DotNetEnv.Env.GetString("SMTP_USER"),
                password: DotNetEnv.Env.GetString("SMTP_PASS")
            ),
            EnableSsl = true,
            Timeout = 10000
        };
        await client.SendMailAsync(message);
    }
}
