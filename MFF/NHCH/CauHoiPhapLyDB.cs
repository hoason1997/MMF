using MFF.DTO.Entities;
using MFF.DTO.Entities.NHCH;
using Microsoft.EntityFrameworkCore;

namespace MFF.Data.NHCH
{
   public class CauHoiDB : DbContext
    {
        public CauHoiDB(DbContextOptions<CauHoiDB> options)
        : base(options)
        {
        }
        public DbSet<CauHoi> CauHoi { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CauHoi>()
                .HasKey(c => new { c.CauHoiID });
        }
    }
}
