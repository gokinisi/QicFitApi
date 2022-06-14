
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configuration.System
{
    public abstract class BaseEntityConfig<TType> : IEntityTypeConfiguration<TType>
        where TType : BaseEntity
    {
        protected string TableName { get; set; }

        public BaseEntityConfig(string tableName)
        {
            TableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<TType> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(obj => obj.Id);
        }
    }
}
