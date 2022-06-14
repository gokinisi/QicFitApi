using Common.DataAccess.EFCore.Configuration.System;
using QicFit.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QicFit.DataAccess.EFCore
{
    public class PreNotificationConfig : BaseEntityConfig<PreNotification>
    {
        public PreNotificationConfig() : base("PreNotification")
        {

        }

        public override void Configure(EntityTypeBuilder<PreNotification> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).IsRequired();
            builder.Property(obj => obj.Email).IsRequired();
            builder.Property(obj => obj.NotificationId).IsRequired();
            builder.Property(obj => obj.RegisteredDate).IsRequired();

        }
    }
}
