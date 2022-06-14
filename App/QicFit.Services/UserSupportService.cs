using QicFit.Services.Infrastructure.Services;
using QicFit.DTO;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Common.Services;
using Common.Services.Infrastructure;

namespace QicFit.Services
{
    public class UserSupportService : BaseService, IUserSupportService
    {
        protected readonly IEmailService emailService;
        protected readonly IConfiguration configuration;
        protected readonly IUserService userService;

        public UserSupportService(ICurrentContextProvider contextProvider, 
                                  IEmailService emailService,
                                  IUserService userService,
                                  IConfiguration configuration) : base(contextProvider)
        {
            this.emailService = emailService;
            this.configuration = configuration;
            this.userService = userService;
        }

        public async Task<SupportMessageDTO> CreateUserMessage(SupportMessageDTO message)
        {
            var userId = Session.UserId;

            var user = await this.userService.GetById(userId);

            message.Email = user.Email;
            message.Name = user.FirstName;

            var emailMessage = new EmailMessageDTO();
            var subject = $"Support Request from {message.Name}";
            var section = configuration.GetSection("SmtpOptions");
            var emailUser = section["User"].ToString();
      
            var outMessage = $"<b>Message:</b> {message.Message}<p><b>Email Address:</b> {message.Email}</p>";

            emailMessage.Message = outMessage;
            emailMessage.To = emailUser;
            emailMessage.From = emailUser;
            emailMessage.Subject = subject;
            emailMessage.ReplyTo = emailUser;
            emailMessage.SmtpOptions = new SmtpOption()
            {
                User = emailUser,
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
