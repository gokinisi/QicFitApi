using QicFit.Services.Infrastructure.Services;
using QicFit.DTO;
using System;
using Microsoft.Extensions.Configuration;

namespace QicFit.Services
{
    public class SupportService : ISupportService
    {
        protected readonly IEmailService emailService;
        protected readonly IConfiguration configuration;

        public SupportService(IEmailService emailService, IConfiguration configuration)
        {
            this.emailService = emailService;
            this.configuration = configuration;
        }

        public SupportMessageDTO Create(SupportMessageDTO message)
        {
            var emailMessage = new EmailMessageDTO();
            var subject = $"Support Request from {message.Name}";
            var section = configuration.GetSection("SmtpOptions");
            var user = section["User"].ToString();

            var outMessage = $"<b>Message:</b> {message.Message}<p><b>Email Address:</b> {message.Email}</p>";

            emailMessage.Message = outMessage;
            emailMessage.To = user;
            emailMessage.From = user;
            emailMessage.Subject = subject;
            emailMessage.ReplyTo = user;
            emailMessage.SmtpOptions = new SmtpOption()
            {
                User = user,
                Password = section["Password"].ToString(),
                Port = Convert.ToInt32(section["Port"]),
                Server = section["Server"].ToString(),
                RequiresAuthentication = Convert.ToBoolean(section["RequiresAuthentication"]),
                UseSsl = Convert.ToBoolean(section["UseSsl"])
            };

            var ret = emailService.Create(emailMessage);

            message.Message = section["Success"].ToString();
            return message;
        }
    }
}
