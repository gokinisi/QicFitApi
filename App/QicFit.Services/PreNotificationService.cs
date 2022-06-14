using Common.Entities;
using Common.Services;
using Common.Services.Infrastructure;
using Common.Utils;
using Common.Utils.Extensions;
using QicFit.DTO;
using QicFit.Entities;
using QicFit.Services.Infrastructure.Repositories;
using QicFit.Services.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MimeKit;
using QicFit.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QicFit.Services
{
    public class PreNotificationService : BaseService, IPreNotificationService
    {
        protected readonly IPreNotificationRepository preNotifcationRepository;
        protected readonly IEmailService emailService;
        protected readonly IConfiguration configuration;
        private IHostEnvironment hostEnvironment;

        public PreNotificationService(ICurrentContextProvider contextProvider,
                                      IEmailService emailService,
                                      IConfiguration configuration,
                                      IPreNotificationRepository preNotifcationRepository,
                                      IHostEnvironment hostEnvironment) : base(contextProvider)
        {
            this.preNotifcationRepository = preNotifcationRepository;
            this.emailService = emailService;
            this.configuration = configuration;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task<IEnumerable<PreNotificationDTO>> GetAll()
        {
            var systemMessage = await preNotifcationRepository.GetList(Session);

            return systemMessage.MapTo<IEnumerable<PreNotificationDTO>>();
        }

        public async Task<PreNotificationDTO> GetById(int id)
        {
            var systemMessage = await preNotifcationRepository.Get(id, Session);

            return systemMessage.MapTo<PreNotificationDTO>();
        }

        public async Task<PreNotificationDTO> Update(PreNotificationDTO preNotification)
        {
            var result = await preNotifcationRepository.Edit(preNotification.MapTo<PreNotification>(), Session);
            return result.MapTo<PreNotificationDTO>();
        }

        public async Task<PreNotificationDTO> Create(PreNotificationDTO preNotification)
        {
            preNotification.RegisteredDate = DateTime.UtcNow;
            preNotification.NotificationId = Guid.NewGuid().ToString();
            
            var result = await preNotifcationRepository.Edit(preNotification.MapTo<PreNotification>(), Session);
            var emailMessage = createEmail(preNotification.Name, preNotification.Email, result.NotificationId);

            var emailResult = emailService.Create(emailMessage);

            return result.MapTo<PreNotificationDTO>();
        }

        private EmailMessageDTO createEmail(string name, string email, string notificationId)
        {
            name = StringCase.ToCamelCase(name);
            var emailMessage = new EmailMessageDTO();
            var subject = $"Thank you {name} for registering for the QicFit Pre-Launch";
            var section = configuration.GetSection("SmtpOptions");
            var user = section["User"].ToString();

            var webRoot = hostEnvironment.ContentRootPath.ToString();

            var templatePath = configuration["Templates:PreLaunch"];
            var builder = new BodyBuilder();

            using (StreamReader SourceReader = File.OpenText(templatePath))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            builder.HtmlBody = builder.HtmlBody.Replace("{#NAME#}", name);
            builder.HtmlBody = builder.HtmlBody.Replace("{#SUBSCRIPTIONID#}", notificationId);

            emailMessage.Message = builder.HtmlBody;
            emailMessage.To = email;
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

            return emailMessage;
        }

        public async Task<PreNotificationDTO> UnsubscribeNotification(SubscriptionDTO subscription)
        {
            try
            {
                var notificationId = subscription.Id;
                var notification = await preNotifcationRepository.GetByNotificationId(notificationId, Session);

                notification.Unsubscribed = true;
                notification.UnsubscribedDate = DateTime.UtcNow;

                var result = await this.Update(notification.MapTo<PreNotificationDTO>());

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Not Found");
            }
            
        }
    }
}
