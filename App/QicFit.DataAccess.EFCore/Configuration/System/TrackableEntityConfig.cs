/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DataAccess.EFCore.Configuration.System;
using QicFit.Entities.System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QicFit.DataAccess.EFCore.Configuration.System
{
    public abstract class TrackableEntityConfig<TType> : BaseTrackableEntityConfig<TType> 
        where TType : TrackableEntity
    {
        private Expression<Func<User, IEnumerable<TType>>> navigationPropertyCreatedBy;
        private Expression<Func<User, IEnumerable<TType>>> navigationPropertyUpdatedBy;

        public TrackableEntityConfig(string tableName,
            Expression<Func<User, IEnumerable<TType>>> navigationPropertyCreatedBy,
            Expression<Func<User, IEnumerable<TType>>> navigationPropertyUpdatedBy)
            : base(tableName)
        {
            this.navigationPropertyCreatedBy = navigationPropertyCreatedBy;
            this.navigationPropertyUpdatedBy = navigationPropertyUpdatedBy;
        }

        public override void Configure(EntityTypeBuilder<TType> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(obj => obj.CreatedByUser)
                .WithMany(this.navigationPropertyCreatedBy)
                .HasForeignKey(obj => obj.CreatedByUserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder
                .HasOne(obj => obj.UpdatedByUser)
                .WithMany(this.navigationPropertyUpdatedBy)
                .HasForeignKey(obj => obj.UpdatedByUserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
