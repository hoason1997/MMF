using MFF.DTO.Entities.SmartLab;
using Microsoft.EntityFrameworkCore;

namespace MFF.Data.SmartLab
{
    public class NHSDBContext : DbContext
    {
        public NHSDBContext(DbContextOptions<NHSDBContext> options)
        : base(options)
        {
        }
        public DbSet<LenhSanXuatImport> LenhSanXuatImport { get; set; }
        public DbSet<LenhSanXuatExport> LenhSanXuatExport { get; set; }
        public DbSet<ThongTinTieuHaoImport> ThongTinTieuHaoImport { get; set; }
        public DbSet<ThongTinTieuHaoExport> ThongTinTieuHaoExport { get; set; }

        public DbSet<HoaChat> HoaChat { get; set; }
        public DbSet<DuongNhapKho> DuongNhapKho { get; set; }
        public DbSet<PhanTichDuongThoNhapKho> PhanTichDuongThoNhapKho { get; set; }
        public DbSet<CauHinhBang> CauHinhBang { get; set; }
        public DbSet<CttvThuocBang> CttvThuocBang { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CauHinhBang>()
             .HasKey(c => new { c.Ma_CauHinhBang });

            builder.Entity<DuongNhapKho>()
           .HasKey(c => new { c.Ma_DuongNhapKho });

            builder.Entity<PhanTichDuongThoNhapKho>()
           .HasKey(c => new { c.Ma_PhanTichDuongThoNhapKho });

            builder.Entity<HoaChat>()
           .HasKey(c => new { c.Ma_HoaChat });

            builder.Entity<CttvThuocBang>()
         .HasKey(c => new { c.Ma_CttvThuocBang });
        }
    }
}
