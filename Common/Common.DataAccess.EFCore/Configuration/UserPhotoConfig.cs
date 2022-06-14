
using Common.DataAccess.EFCore.Configuration.System;
using Common.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration
{
    public class UserPhotoConfig : BaseEntityConfig<UserPhoto>
    {
        public UserPhotoConfig() : base("UserPhotos")
        { }

        public override void Configure(EntityTypeBuilder<UserPhoto> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Image).IsRequired();
        }
    }
}
