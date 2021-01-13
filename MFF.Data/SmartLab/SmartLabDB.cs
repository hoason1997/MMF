using MFF.DTO.Entities.Identity;
using MFF.DTO.Entities.SmartLab;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MFF.Data.SmartLab
{
    public class SmartLabDB : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public SmartLabDB(DbContextOptions<SmartLabDB> options)
        : base(options)
        {
        }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuPermission> MenuPermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ApplicationRoleMenu> RoleMenus { get; set; }
        public DbSet<BanCanMia> BanCanMia { get; set; }
        public DbSet<LenhSanXuatERP> LenhSanXuatERP { get; set; }
        public DbSet<ThongTinTieuHao> ThongTinTieuHao { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<LenhSanXuatERP>()
               .HasKey(c => new { c.Id });
            builder.Entity<LenhSanXuatERP>().Property(ent => ent.Id).ValueGeneratedOnAdd();


            base.OnModelCreating(builder);
            builder.Entity<ThongTinTieuHao>()
               .HasKey(c => new { c.Id });
            builder.Entity<ThongTinTieuHao>().Property(ent => ent.Id).ValueGeneratedOnAdd();

            builder.Entity<BanCanMia>()
                .HasKey(c => new { c.Ma_BanCanMia });

            builder.Entity<MenuItem>(item =>
            {
                item.ToTable("AspNetMenu");
                item.HasMany(y => y.Children)
                    .WithOne(r => r.ParentItem)
                    .HasForeignKey(u => u.ParentId);

                item.HasMany(t => t.RoleMenus)
                    .WithOne(u => u.MenuItem)
                    .HasForeignKey(r => r.MenuId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<ApplicationRoleMenu>(roleMenu =>
            {
                roleMenu.ToTable("AspNetRoleMenu");

                roleMenu.HasOne(o => o.Role)
                    .WithMany(u => u.RoleMenus)
                    .HasForeignKey(e => e.RoleId)
                    .OnDelete(DeleteBehavior.NoAction);

                roleMenu.HasOne(o => o.MenuItem)
                    .WithMany(u => u.RoleMenus)
                    .HasForeignKey(e => e.MenuId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<MenuPermission>(mp =>
            {
                mp.ToTable("MenuPermission");

                mp.HasKey(l => new { l.RoleMenuId, l.PermissionId });

                mp.HasOne(o => o.Permission)
                    .WithMany(i => i.MenuPermissions)
                    .IsRequired();

                mp.HasOne(o => o.RoleMenu)
                    .WithMany(i => i.Permissions)
                    .IsRequired();
            });

            builder.Entity<Permission>(mp =>
            {
                mp.ToTable("Permission");

                mp.HasKey(l => l.Id);

                mp.HasMany(o => o.MenuPermissions)
                    .WithOne(i => i.Permission)
                    .HasForeignKey(y => y.PermissionId);
            });

        }
    }

    public class TTCSLabDB:DbContext
    {
        public TTCSLabDB(DbContextOptions<TTCSLabDB> options)
        : base(options)
        {
        }
        public DbSet<LenhSanXuatERP> LenhSanXuatERP { get; set; }
        public DbSet<ThongTinTieuHao> ThongTinTieuHao { get; set; }
    }
    public class BHSTALabDB : DbContext
    {
        public BHSTALabDB(DbContextOptions<BHSTALabDB> options)
        : base(options)
        {
        }
        public DbSet<LenhSanXuatERP> LenhSanXuatERP { get; set; }
        public DbSet<ThongTinTieuHao> ThongTinTieuHao { get; set; }
    }
}
