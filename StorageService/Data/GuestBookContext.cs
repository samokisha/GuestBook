using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using StorageService.Model; // TODO: Maybe better using MessageContract

namespace StorageService.Data
{
    public class GuestBookContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public GuestBookContext(DbContextOptions<GuestBookContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Comment>()
                .Property(c => c.CommentType)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            
            ChangeTracker
                .Entries<Comment>()
                .Where(e => e.State == EntityState.Added)
                .ToList()
                .ForEach(e => e.Entity.CreatedAt = DateTime.UtcNow);
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}