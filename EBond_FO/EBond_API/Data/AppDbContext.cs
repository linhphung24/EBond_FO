namespace EBond_API.Data
{
    using EBond_API.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                    .HasDefaultValueSql("NEWID()");  // auto-generate Guid from SQL

                entity.Property(x => x.TokenHash)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(x => x.ReplacedByTokenHash)
                    .HasMaxLength(255);

                entity.Property(x => x.IpAddress)
                    .HasMaxLength(50);

                entity.HasIndex(x => x.TokenHash);
                entity.HasIndex(x => x.UserID);
            });
        }
    }
}
