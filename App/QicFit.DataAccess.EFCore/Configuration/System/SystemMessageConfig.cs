using Common.DataAccess.EFCore.Configuration.System;
using Common.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QicFit.DataAccess.EFCore
{
    public class SystemMessageConfig : BaseEntityConfig<SystemMessage>
    {

        public SystemMessageConfig() : base("SystemMessages")
        {

        }
        public override void Configure(EntityTypeBuilder<SystemMessage> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name).HasMaxLength(25).IsRequired();
            builder.Property(obj => obj.Text).IsRequired();
            builder.Property(obj => obj.Order).IsRequired();
            builder.Property(obj => obj.StartDate).IsRequired();
            builder.Property(obj => obj.ExpirationDate).IsRequired();
        }
    }
}
