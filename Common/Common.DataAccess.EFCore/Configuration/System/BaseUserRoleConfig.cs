
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration.System
{
    public class BaseUserRoleConfig : IEntityTypeConfiguration<BaseUserRole>
    {
        public void Configure(EntityTypeBuilder<BaseUserRole> builder)
        {
            builder.ToTable("UserRoles");
            builder.HasKey("UserId", "RoleId");
            builder.Property(obj => obj.RoleId).IsRequired();
            builder.Property(obj => obj.UserId).IsRequired();

            builder.Ignore(x => x.Role);
            builder.Ignore(x => x.User);

            builder
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(r => r.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
