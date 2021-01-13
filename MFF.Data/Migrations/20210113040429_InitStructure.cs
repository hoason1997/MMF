using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MFF.Data.Migrations
{
    public partial class InitStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    Url = table.Column<string>(maxLength: 150, nullable: true)
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BanCanMia",
                columns: table => new
                {
                    Ma_BanCanMia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(nullable: true),
                    TaoBoi = table.Column<string>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true),
                    CapNhatBoi = table.Column<string>(nullable: true),
                    Ma_SoCa = table.Column<int>(nullable: true),
                    Ma_Cttv = table.Column<int>(nullable: true),
                    Ngay = table.Column<DateTime>(nullable: true),
                    Gio = table.Column<string>(nullable: true),
                    TanMia = table.Column<decimal>(nullable: true),
                    TanMiaTho = table.Column<decimal>(nullable: true),
                    Xoa = table.Column<bool>(nullable: true),
                    Mota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanCanMia", x => x.Ma_BanCanMia);
                });

            migrationBuilder.CreateTable(
                name: "LenhSanXuatERP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WORK_ORDER_ID = table.Column<long>(nullable: false),
                    BUSINESS_UNIT_NAME = table.Column<string>(maxLength: 240, nullable: true),
                    BUSINESS_UNIT_ID = table.Column<long>(nullable: false),
                    ORGANIZATION_CODE = table.Column<string>(maxLength: 30, nullable: true),
                    ORGANIZATION_NAME = table.Column<string>(maxLength: 240, nullable: true),
                    WORK_ORDER_NUMBER = table.Column<string>(maxLength: 120, nullable: true),
                    WO_TYPE = table.Column<string>(maxLength: 50, nullable: true),
                    WO_STATUS_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    PLANNED_START_DATE = table.Column<DateTime>(nullable: false),
                    PLANNED_COMPLETION_DATE = table.Column<DateTime>(nullable: false),
                    RELEASED_DATE = table.Column<DateTime>(nullable: false),
                    ACTUAL_COMPLETION_DATE = table.Column<DateTime>(nullable: false),
                    CLOSED_DATE = table.Column<DateTime>(nullable: false),
                    ITEM_NUMBER = table.Column<string>(maxLength: 240, nullable: true),
                    ITEM_NAME = table.Column<string>(maxLength: 240, nullable: true),
                    UOM_CODE = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LenhSanXuatERP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinTieuHao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BUSINESS_UNIT_NAME = table.Column<string>(maxLength: 240, nullable: true),
                    BUSINESS_UNIT_ID = table.Column<long>(nullable: false),
                    ORGANIZATION_CODE = table.Column<string>(maxLength: 30, nullable: true),
                    ORGANIZATION_NAME = table.Column<string>(maxLength: 240, nullable: true),
                    WORK_ORDER_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    ITEM_NUMBER = table.Column<string>(maxLength: 240, nullable: true),
                    ITEM_NAME = table.Column<string>(maxLength: 240, nullable: true),
                    TRANSACTION_TYPE = table.Column<string>(maxLength: 240, nullable: true),
                    TRANSACTION_QTY = table.Column<int>(nullable: false),
                    UOM_CODE = table.Column<string>(maxLength: 50, nullable: true),
                    TRANSACTION_DATE = table.Column<DateTime>(nullable: false),
                    LOT_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    POL_TYPE = table.Column<string>(maxLength: 120, nullable: true),
                    SUB_INV_CODE = table.Column<string>(maxLength: 18, nullable: true),
                    LOCATOR = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinTieuHao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        name: "FK_AspNetRoleMenu_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleMenu_MenuId",
                table: "AspNetRoleMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleMenu_RoleId",
                table: "AspNetRoleMenu",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_PermissionId",
                table: "MenuPermission",
                column: "PermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BanCanMia");

            migrationBuilder.DropTable(
                name: "LenhSanXuatERP");

            migrationBuilder.DropTable(
                name: "MenuPermission");

            migrationBuilder.DropTable(
                name: "ThongTinTieuHao");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "AspNetRoleMenu");

            migrationBuilder.DropTable(
                name: "AspNetMenu");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}
