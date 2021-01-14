using MFF.DTO.Entities.SmartLab;
using Microsoft.EntityFrameworkCore;

namespace MFF.Data.SmartLab
{
    public class PHANRANGDB : DbContext
    {
        public PHANRANGDB(DbContextOptions<PHANRANGDB> options)
        : base(options)
        {
        }
        public DbSet<LenhSanXuatERP> LenhSanXuatERP { get; set; }
        public DbSet<ThongTinTieuHao> ThongTinTieuHao { get; set; }
    }
}
