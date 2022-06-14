
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration.System
{
    public class BaseUserConfig : BaseEntityConfig<BaseUser>
    {
        public BaseUserConfig() : base("Users") { }

        public override void Configure(EntityTypeBuilder<BaseUser> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.FirstName);
            builder.Property(obj => obj.LastName);
            builder.Property(obj => obj.UserName).IsRequired();
            builder.Property(obj => obj.Password);
            builder.Property(obj => obj.Email).IsRequired();
            builder.Property(obj => obj.Age);
            builder.Property(obj => obj.AcceptUserAgreement).IsRequired().HasDefaultValue(false);
            builder.Property(obj => obj.AcceptCovidAgreement).IsRequired().HasDefaultValue(false);
            builder.Property(obj => obj.AcceptUserAgreementDate);
            builder.Property(obj => obj.AcceptCovidAgreementDate);

            builder.Property(obj => obj.CityId);
            builder.Property(obj => obj.StateId);
            builder.Property(obj => obj.GenderId);
            builder.Property(obj => obj.AddressZipCode).HasColumnName("ZipCode");
            builder.Property(obj => obj.AddressLat).HasColumnName("Lat");
            builder.Property(obj => obj.AddressLng).HasColumnName("Lng");

            builder
             .HasOne(obj => obj.Photo)
             .WithOne()
             .HasForeignKey<UserPhoto>(obj => obj.Id)
             .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasOne(obj => obj.Settings)
            //    .WithOne()
            //    .HasForeignKey<Settings>(obj => obj.Id)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(obj => obj.UserRoles)
                .WithOne()
                .HasForeignKey(obj => obj.UserId)
                .IsRequired();

            builder
                .HasMany(obj => obj.Claims)
                .WithOne()
                .HasForeignKey(obj => obj.UserId)
                .IsRequired();
        }
    }
}
