
using Common.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration.System
{
    public abstract class BaseTrackableEntityConfig<TType> : BaseEntityConfig<TType> 
        where TType : BaseTrackableEntity
    {
        public BaseTrackableEntityConfig(string tableName) : base(tableName)
        { }

        public override void Configure(EntityTypeBuilder<TType> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.CreatedByUserId).IsRequired();
            builder.Property(obj => obj.CreatedDate).IsRequired();
            builder.Property(obj => obj.UpdatedByUserId);
            builder.Property(obj => obj.UpdatedDate);
        }
    }
}
