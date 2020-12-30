using MFF.DTO.Entities.Identity;
using MFF.DTO.Entities.SmartLab;
using Microsoft.EntityFrameworkCore;

namespace MFF.Data.SmartLab
{
    public class SmartLabDB : DbContext
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
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
}
