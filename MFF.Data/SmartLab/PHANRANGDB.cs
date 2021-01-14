using MFF.DTO.Entities.SmartLab;
using Microsoft.EntityFrameworkCore;

namespace MFF.Data.SmartLab
{
    public class SECDB : DbContext
    {
        public SECDB(DbContextOptions<SECDB> options)
        : base(options)
        {
        }
        public DbSet<LenhSanXuatERP> LenhSanXuatERP { get; set; }
        public DbSet<ThongTinTieuHao> ThongTinTieuHao { get; set; }
    }
}
