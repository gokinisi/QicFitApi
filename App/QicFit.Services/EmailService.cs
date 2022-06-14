
using QicFit.Services.Infrastructure.Services;
using MailKit.Net.Smtp;
using MimeKit;
using QicFit.DTO;
using System;
using System.Threading.Tasks;

namespace QicFit.Services
{
    public class EmailService : IEmailService
    {
        public EmailMessageDTO Create(EmailMessageDTO message)
        {
            if (string.IsNullOrWhiteSpace(message.To))
            {
                throw new ArgumentException("no to address provided");
            }

            if (string.IsNullOrWhiteSpace(message.From))
            {
                throw new ArgumentException("no from address provided");
            }

            if (string.IsNullOrWhiteSpace(message.Subject))
            {
                throw new ArgumentException("no subject provided");
            }

            var hasHtml = !string.IsNullOrWhiteSpace(message.Message);
            var outMessage = new MimeMessage();

            outMessage.From.Add(new MailboxAddress("", message.From));
            if (!string.IsNullOrWhiteSpace(message.ReplyTo))
            {
                outMessage.ReplyTo.Add(new MailboxAddress("", message.ReplyTo));
            }

            outMessage.To.Add(new MailboxAddress("", message.To));
            outMessage.Subject = message.Subject;


            if (!string.IsNullOrEmpty(message.Cc))
            {
                outMessage.Cc.Add(new MailboxAddress("", message.Cc));
            }

            BodyBuilder bodyBuilder = new BodyBuilder();

            if (hasHtml)
            {
                bodyBuilder.HtmlBody = message.Message;
            }

            outMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(
                   message.SmtpOptions.Server,
                   message.SmtpOptions.Port,
                   message.SmtpOptions.UseSsl
                 );

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                if (message.SmtpOptions.RequiresAuthentication)
                {
                    client.Authenticate(message.SmtpOptions.User, message.SmtpOptions.Password);
                }

                client.Send(outMessage);
                client.Disconnect(true);
            }

            return message;
        }
    }
}
