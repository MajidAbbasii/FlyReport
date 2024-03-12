using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Text.Json;
using FlyApp.Classes;
using FlyApp.Entities;
using FlyApp.Extensions;
using FlyApp.Infrastructure;
using FlyApp.Log;
using Microsoft.EntityFrameworkCore;

namespace FlyApp.Services;

public class MailService : ServiceBase
{
    private readonly EventLogger _eventLogger = new("FlyService");
    private const string FromEmail = "m.abbasi201@gmail.com";
    private const string ToEmail = "m.abbasi201@gmail.com";
    private const string Subject = "CheatFlights";

    public async Task SendEmail(string body)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(body))
                return;
    
            using var message = new MailMessage(FromEmail, ToEmail);
            message.Subject = Subject;
            message.Body = body;
    
            using var client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(FromEmail, "mtwh ggno icnb scxz");
            client.EnableSsl = true;
    
            await client.SendMailAsync(message);
        }
        catch (Exception e)
        {
            _eventLogger.LogError($"An error occurred: {e.Message}");
        }
    }
}