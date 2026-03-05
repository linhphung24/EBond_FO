using EBond_FO.Models;
using Microsoft.EntityFrameworkCore;

namespace EBond_FO.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<IFG_Corporate_Bond_Info> IFG_Corporate_Bond_Info { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IFG_Corporate_Bond_Info>(entity =>
            {
                entity.ToTable("IFG_Corporate_Bond_Info");
                entity.HasKey(e => e.id);
            });
        }
    }
}
