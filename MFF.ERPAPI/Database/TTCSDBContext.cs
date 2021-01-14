using MFF.ERPAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace MFF.ERPAPI.Database
{
    public class TTCSDBContext : DbContext
    {
        public TTCSDBContext(DbContextOptions<TTCSDBContext> options)
        : base(options)
        {
        }
        public DbSet<LenhSanXuatERP> LenhSanXuatERP { get; set; }
        public DbSet<ThongTinTieuHao> ThongTinTieuHao { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
