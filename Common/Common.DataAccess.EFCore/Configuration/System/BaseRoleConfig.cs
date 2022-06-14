
using Common.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration.System
{
    public class BaseRoleConfig : BaseEntityConfig<BaseRole>
    {
        public BaseRoleConfig() : base("Roles") { }

        public override void Configure(EntityTypeBuilder<BaseRole> builder)
        {
            base.Configure(builder);
            builder.Property(obj => obj.Name);

            builder
                .HasMany(r => r.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        }
    }
}
