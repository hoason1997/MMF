using MFF.DTO.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace MFF.Data
{
    public class MFFDbContext : DbContext
    {
        public DbSet<MFFItem> MFFItem { get; set; }
        public DbSet<User> User { get; set; }

        public MFFDbContext(DbContextOptions<MFFDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MFFDbContext).Assembly);
        }
    }
}
