using Microsoft.EntityFrameworkCore;
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
    }
}