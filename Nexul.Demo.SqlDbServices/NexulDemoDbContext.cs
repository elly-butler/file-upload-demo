using Microsoft.EntityFrameworkCore;
using Nexul.Demo.Files;

namespace Nexul.Demo.SqlDbServices
{
    public class NexulDemoDbContext : DbContext
    {
        public NexulDemoDbContext(DbContextOptions<NexulDemoDbContext> options) : base(options) { }


        public DbSet<FileMetadata> FileMetadata { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<FileImageAlternateMetadata> FileImageAlternateMetadata { get; set; }
        public DbSet<FileImageAlternate> FileImageAlternate { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FileMetadata>().OwnsOne(x => x.Audit);
            builder.Entity<FileImageAlternateMetadata>().OwnsOne(x => x.Audit);
        }
    }
}
