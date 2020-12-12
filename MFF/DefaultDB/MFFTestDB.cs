using MFF.DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace MFF.Data
{
    public class MFFTestDB:DbContext
    {
        public MFFTestDB(DbContextOptions<MFFTestDB> options)
         : base(options)
        {
        }
        public DbSet<NhanVien> NhanVien { get; set; }

    }
}
