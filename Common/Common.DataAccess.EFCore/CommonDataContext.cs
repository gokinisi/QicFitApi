
using Common.DataAccess.EFCore.Configuration;
using Common.Entities;
using QicFit.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Common.DataAccess.EFCore
{
    public abstract class CommonDataContext : DbContext
    {
        public ContextSession Session { get; set; }

        public DbSet<UserPhoto> UserPhotos { get; set; }

        public DbSet<Gender> Gender { get; set; }

        public DbSet<Settings> Settings { get; set; }

        protected CommonDataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserPhotoConfig());
            modelBuilder.ApplyConfiguration(new GenderConfig());
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            FillTrackingData();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            FillTrackingData();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void FillTrackingData()
        {
            foreach (var item in ChangeTracker.Entries<BaseTrackableEntity>()
                .Where(item => item.State == EntityState.Added || item.State == EntityState.Modified))
            {
                FillTrackingData(item);
            }
        }

        protected void FillTrackingData(EntityEntry<BaseTrackableEntity> entry)
        {
            var now = DateTime.Now;
            var userId = Session != null ? Session.UserId : 2;

            entry.Entity.UpdatedByUserId = userId;
            entry.Entity.UpdatedDate = now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedByUserId = userId;
                entry.Entity.CreatedDate = now;
            }
            else
            {
                entry.Property(p => p.CreatedDate).IsModified = false;
                entry.Property(p => p.CreatedByUserId).IsModified = false;
            }
        }
    }
}
