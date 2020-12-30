using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MFF.WEB.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    Url = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetMenu_AspNetMenu_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AspNetMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BanCanMia",
                columns: table => new
                {
                    Ma_BanCanMia = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: false),
                    Ma_SoCa = table.Column<int>(nullable: true),
                    Ma_Cttv = table.Column<int>(nullable: true),
                    Ngay = table.Column<DateTime>(nullable: true),
                    Gio = table.Column<string>(nullable: true),
                    TanMia = table.Column<decimal>(nullable: true),
                    TanMiaTho = table.Column<decimal>(nullable: true),
                    Xoa = table.Column<bool>(nullable: true),
                    Mota = table.Column<string>(nullable: true),
                    TaoBoi = table.Column<string>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true),
                    CapNhatBoi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanCanMia", x => x.Ma_BanCanMia);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: true),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleMenu_AspNetMenu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "AspNetMenu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetRoleMenu_ApplicationRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuPermission",
                columns: table => new
                {
                    RoleMenuId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission", x => new { x.RoleMenuId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_MenuPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuPermission_AspNetRoleMenu_RoleMenuId",
                        column: x => x.RoleMenuId,
                        principalTable: "AspNetRoleMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetMenu_ParentId",
                table: "AspNetMenu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleMenu_MenuId",
                table: "AspNetRoleMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleMenu_RoleId",
                table: "AspNetRoleMenu",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_PermissionId",
                table: "MenuPermission",
                column: "PermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BanCanMia");

            migrationBuilder.DropTable(
                name: "MenuPermission");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "AspNetRoleMenu");

            migrationBuilder.DropTable(
                name: "AspNetMenu");

            migrationBuilder.DropTable(
                name: "ApplicationRole");
        }
    }
}
