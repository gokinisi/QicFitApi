
using Common.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration.System
{
    public class BaseUserClaimConfig : BaseEntityConfig<BaseUserClaim>
    {
        public BaseUserClaimConfig() : base("UserClaims") { }

        public override void Configure(EntityTypeBuilder<BaseUserClaim> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.ClaimType).IsRequired();
            builder.Property(obj => obj.ClaimValue).IsRequired();

            builder.Ignore(obj => obj.User);
        }
    }
}
