using MFF.Data.SmartLab;
using MFF.DTO.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MFF.WEB.Data
{
    public class InitData : IInitData
    {
        private readonly ApplicationUserManager _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SmartLabDB _dbContext;

        public InitData(ApplicationUserManager manager, RoleManager<ApplicationRole> roleManager, SmartLabDB dbContext)
        {
            _userManager = manager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task InitBasedata()
        {
            var adminRoleId = "79AC1299-E87C-446C-AD69-ECDFE1A5EEA1";
            var devRoleId = "B6275249-B4F1-4738-963D-7C40B23AF8B7";
            var userRoleId = "7AAFEC08-0A31-4588-A290-62B12F888920";

            if (await _dbContext.Permissions.CountAsync() == 0)
            {
                await _dbContext.Permissions.AddRangeAsync(new List<Permission>
                {
                    new Permission {Name = "View"},
                    new Permission {Name = "Create"},
                    new Permission {Name = "Update"},
                    new Permission {Name = "Delete"},
                    new Permission {Name = "Upload"},
                    new Permission {Name = "Publish"}
                });

            }

            if (await _dbContext.MenuItems.CountAsync() == 0)
            {
                var mainMenu = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Menu", ParentId = null, Icon = "fa fa-list", Url = null });
                await _dbContext.SaveChangesAsync();

                #region first child menu

                var baocaokiemnghiem = await _dbContext.MenuItems.AddAsync(new MenuItem { Title = "Báo cáo kiểm nghiệm", ParentId = mainMenu.Entity.Id, Icon = "", Url = null });
                var baocaosxtieuthu = await _dbContext.MenuItems.AddAsync(new MenuItem { Title = "Báo cáo sx-tiêu thụ điện", ParentId = mainMenu.Entity.Id, Icon = "", Url = null });
                var baocaotieuthuhoi = await _dbContext.MenuItems.AddAsync(new MenuItem { Title = "Báo cáo sx-tiêu thụ hơi", ParentId = mainMenu.Entity.Id, Icon = "", Url = null });
                var phanvisinh = await _dbContext.MenuItems.AddAsync(new MenuItem { Title = "Báo cáo phân vi sinh (view)", Icon = null, ParentId = mainMenu.Entity.Id, Url = null });

                var traodoithongtin = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Trao đổi thông tin", ParentId = mainMenu.Entity.Id, Icon = "fa fa-exchange", Url = null });
                var theodoi = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Theo dõi", ParentId = mainMenu.Entity.Id, Icon = "fa fa-retweet", Url = null });
                var nhapslieu = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Nhập số liệu", ParentId = mainMenu.Entity.Id, Icon = "fa fa-retweet", Url = null });
                var Quantrihethong = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Quản trị hệ thống", ParentId = mainMenu.Entity.Id, Icon = "fa fa-cog", Url = null });

                await _dbContext.SaveChangesAsync();
                await _dbContext.MenuItems.AddAsync(new MenuItem { Title = "Báo cáo phân vi sinh (view)", Icon = null, ParentId = phanvisinh.Entity.Id, Url = "bao-cao-phan-vi-sinh" });
                #endregion

                #region Báo cáo kiểm nghiệm
                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Báo cáo phân tích ngày",Icon=null,ParentId=baocaokiemnghiem.Entity.Id,Url=baocaokiemnghiem.Entity.Url +"/bao-cao-phan-tich-ngay"},
                        new MenuItem{Title="Báo cáo sản xuât theo ngày",Icon=null,ParentId=baocaokiemnghiem.Entity.Id,Url=baocaokiemnghiem.Entity.Url +"/bao-cao-san-xuat-theo-ngay"},
                            new MenuItem { Title = "Báo cáo SX thời đoạn", Icon = null, ParentId = baocaokiemnghiem.Entity.Id, Url = baocaokiemnghiem.Entity.Url + "/bao-cao-san-xuat-thoi-doan" },
                                new MenuItem { Title = "Báo cáo phân tích từ ngày đến ngày", Icon = null, ParentId = baocaokiemnghiem.Entity.Id, Url = baocaokiemnghiem.Entity.Url + "/bao-cao-phan-tich-tu-ngay-den-ngay" },
                                     new MenuItem { Title = "Vẽ biểu đồ SPC", Icon = null, ParentId = baocaokiemnghiem.Entity.Id, Url = baocaokiemnghiem.Entity.Url + "/ve-bieu-do-spc" },
                                         new MenuItem { Title = "Biểu đồ theo dõi sản xuất", Icon = null, ParentId = baocaokiemnghiem.Entity.Id, Url = baocaokiemnghiem.Entity.Url + "/bieu-do-theo-doi-san-xuat" }
                });
                await _dbContext.SaveChangesAsync();
                #endregion

                #region Báo cáo sx-tiêu thụ điện
                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Báo cáo điện tự phát",Icon=null,ParentId=baocaosxtieuthu.Entity.Id,Url=baocaosxtieuthu.Entity.Url +"/bao-cao-dien-tu-phat"},
                        new MenuItem{Title="Báo cáo EVN",Icon=null,ParentId=baocaosxtieuthu.Entity.Id,Url=baocaosxtieuthu.Entity.Url +"/bao-cao-EVN"},
                            new MenuItem { Title = "Điện tiêu thụ từng khu vực", Icon = null, ParentId = baocaosxtieuthu.Entity.Id, Url = baocaosxtieuthu.Entity.Url + "/dien-tieu-thu-tung-khu-vuc" },
                });
                await _dbContext.SaveChangesAsync();
                #endregion

                #region Báo cáo sx-tiêu thụ hơi     
                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Báo cáo sản lượng hơi",Icon=null,ParentId=baocaotieuthuhoi.Entity.Id,Url=baocaotieuthuhoi.Entity.Url +"/bao-cao-san-luong-hoi"},
                });
                await _dbContext.SaveChangesAsync();
                #endregion

                #region Trao đổi thông tin
                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Thông báo Tất cả phòng ban, cá nhân",Icon=null,ParentId=traodoithongtin.Entity.Id,Url=traodoithongtin.Entity.Url +"/thong-bao-phong-ban-ca-nhan"},
                      new MenuItem{Title="Thông báo ",Icon=null,ParentId=traodoithongtin.Entity.Id,Url=traodoithongtin.Entity.Url +"/thong-bao-chung"},

                });
                await _dbContext.SaveChangesAsync();
                #endregion

                #region Theo dõi
                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Thông tin nhanh(view)",Icon=null,ParentId=theodoi.Entity.Id,Url=theodoi.Entity.Url +"/thong-tin-nhanh"},
                    new MenuItem{Title="Báo cáo hóa chất vật tư",Icon=null,ParentId=theodoi.Entity.Id,Url=theodoi.Entity.Url +"/bao-cao-hoa-chat-vat-tu"},
                    new MenuItem{Title="Kiểm tra cân",Icon=null,ParentId=theodoi.Entity.Id,Url=theodoi.Entity.Url +"/kiem-tra-can"},
                    new MenuItem{Title="Sổ giao ca",Icon=null,ParentId=theodoi.Entity.Id,Url=theodoi.Entity.Url +"/so-giao-ca"},
                    new MenuItem{Title="Ghi nhận sự cố",Icon=null,ParentId=theodoi.Entity.Id,Url=theodoi.Entity.Url +"/ghi-nhan-su-co"},
                });
                await _dbContext.SaveChangesAsync();
                #endregion


                #region Nhập số liệu
                #region first child menu
                var solieubancan = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Số liệu từ bàn cân mía", ParentId = nhapslieu.Entity.Id, Icon = "fa fa-retweet", Url = nhapslieu.Entity.Url + "/so-lieu-ban-can-mia" });
                var dulieuBCP = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Dữ liệu BCP", ParentId = nhapslieu.Entity.Id, Icon = "fa fa-retweet", Url = nhapslieu.Entity.Url + "/du-lieu-BCP" });
                var duongsanxuat = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Đường sản xuất", ParentId = nhapslieu.Entity.Id, Icon = "fa fa-retweet", Url = nhapslieu.Entity.Url + "/duong-san-xuat" });
                var xulynuocthai = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Xử lý nước thải", ParentId = nhapslieu.Entity.Id, Icon = "fa fa-retweet", Url = nhapslieu.Entity.Url + "/xu-ly-nuoc-thai" });
                var phongkiemnghiem = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Phòng kiểm nghiệm", ParentId = nhapslieu.Entity.Id, Icon = "fa fa-retweet", Url = nhapslieu.Entity.Url + "/phong-kiem-nghiem" });
            

                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Vật tư hóa chất",Icon=null,ParentId=nhapslieu.Entity.Id,Url=nhapslieu.Entity.Url +"/vat-tu-hoa-chat"},
                        new MenuItem{Title="Dữ liệu SX- Tiêu thụ điện",Icon=null,ParentId=nhapslieu.Entity.Id,Url=nhapslieu.Entity.Url +"/du-lieu-sx-tieu-thu-dien"},
                            new MenuItem{Title="Dữ liệu SX- Tiêu thụ hơi",Icon=null,ParentId=nhapslieu.Entity.Id,Url=nhapslieu.Entity.Url +"/du-lieu-sx-tieu-thu-hoi"},
                                new MenuItem{Title="Phân vi sinh",Icon=null,ParentId=nhapslieu.Entity.Id,Url=nhapslieu.Entity.Url +"/phan-vi-sinh"},
                                    new MenuItem{Title="Thực hiện mục tiêu trong tháng",Icon=null,ParentId=nhapslieu.Entity.Id,Url=nhapslieu.Entity.Url +"/thuc-hien-muc-tieu-trong-thang"},
                                        new MenuItem{Title="Thực hiên mục tiêu trong vụ",Icon=null,ParentId=nhapslieu.Entity.Id,Url=nhapslieu.Entity.Url +"/thuc-hien-muc-tieu-trong-vu"},
                                            new MenuItem{Title="Thực hiện mục tiêu báo cáo ngày",Icon=null,ParentId=nhapslieu.Entity.Id,Url=nhapslieu.Entity.Url +"/thuc-hien-muc-tieu-bao-cao-ngay"},
                                                 new MenuItem{Title="Định mức vật tư hóa chất",Icon=null,ParentId=nhapslieu.Entity.Id,Url=nhapslieu.Entity.Url +"/dinh-muc-vat-tu-hoat-chat"},
                });
            
                await _dbContext.SaveChangesAsync();

                #endregion

                #region second child menu
                var miahanggio = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Mía hàng giờ", ParentId = solieubancan.Entity.Id, Icon = "fa fa-retweet", Url = solieubancan.Entity.Url + "/mia-hang-gio" });
                var kiemtracan = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Kiểm tra cân", ParentId = solieubancan.Entity.Id, Icon = "fa fa-retweet", Url = solieubancan.Entity.Url + "/kiem-tra-can" });
                await _dbContext.SaveChangesAsync();
                #endregion

                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Tồn mía trên sân",Icon=null,ParentId=dulieuBCP.Entity.Id,Url=dulieuBCP.Entity.Url +"/ton-mia-tren-can"},
                       new MenuItem{Title="Các bồn bán chế phẩm",Icon=null,ParentId=dulieuBCP.Entity.Id,Url=dulieuBCP.Entity.Url +"/cac-bon-ban-che-pham"},
                          new MenuItem{Title="Đường sản xuất",Icon=null,ParentId=dulieuBCP.Entity.Id,Url=dulieuBCP.Entity.Url +"/duong-san-xuat"},
                });
                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Đường nhập kho",Icon=null,ParentId=duongsanxuat.Entity.Id,Url=duongsanxuat.Entity.Url +"/duong-nhan-kho"},
                       new MenuItem{Title="Đường xuất kho",Icon=null,ParentId=duongsanxuat.Entity.Id,Url=duongsanxuat.Entity.Url +"/duong-xuat-kho"},
                });
                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Lượng nước thải",Icon=null,ParentId=xulynuocthai.Entity.Id,Url=xulynuocthai.Entity.Url +"/luong-nuoc-thai"},
                       new MenuItem{Title="Cân đóng bao",Icon=null,ParentId=xulynuocthai.Entity.Id,Url=xulynuocthai.Entity.Url +"/can-dong-bao"},
                });
                await _dbContext.SaveChangesAsync();

                #region  child menu phòng kiểm nghiệm

                var nhaplieubaocao = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Nhập số liệu báo cáo", ParentId = phongkiemnghiem.Entity.Id, Icon = "fa fa-retweet", Url = phongkiemnghiem.Entity.Url + "/nhap-so-lieu-bao-cao" });
                var nhaplieuphantich = await _dbContext.MenuItems.AddAsync(new MenuItem
                { Title = "Nhập số liệu phân tích", ParentId = phongkiemnghiem.Entity.Id, Icon = "fa fa-retweet", Url = phongkiemnghiem.Entity.Url + "/nhap-so-lieu-phan-tich" });
                await _dbContext.SaveChangesAsync();

                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Kết quả phân tích các bồn chế phẩm",Icon=null,ParentId=nhaplieubaocao.Entity.Id,Url=nhaplieubaocao.Entity.Url +"/ket-qua-phan-tich-cac-bon-CP"},
                        new MenuItem{Title="Nhập số liệu làm Báo cáo ngày",Icon=null,ParentId=nhaplieubaocao.Entity.Id,Url=nhaplieubaocao.Entity.Url +"/nhap-so-lieu-bao-cao-ngay"},
                          new MenuItem{Title="Nhập liệu mùa vụ trước",Icon=null,ParentId=nhaplieubaocao.Entity.Id,Url=nhaplieubaocao.Entity.Url +"/nhap-lieu-mua-vu-truoc"},
                            new MenuItem{Title=" Cấu hình giá trị các bồn bán chế phẩm",Icon=null,ParentId=nhaplieubaocao.Entity.Id,Url=nhaplieubaocao.Entity.Url +"/cau-hinh-gia-tri-cac-bon-BCP"},
                });
                await _dbContext.SaveChangesAsync();
                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Nhập dữ liệu ca",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/nhap-du-lieu-ca"},
                        new MenuItem{Title="Nhập mía nước mía",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/nhap-mia-nuoc-mia"},
                           new MenuItem{Title="Đường non tho",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/duong-non-tho"},
                              new MenuItem{Title="Hóa chế luyện",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/hoa-che-luyen"},
                                 new MenuItem{Title="Đường sau sấy",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/duong-sau-say"},
                                    new MenuItem{Title="Đường thành phẩm",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/duong-thanh-pham"},
                                       new MenuItem{Title="Bùn",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/bun"},
                                          new MenuItem{Title="Phân tích RS",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/phan-tich-rs"},
                                             new MenuItem{Title="Nước lò",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/nuoc-lo"},
                                                 new MenuItem{Title="Nước thải",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/nuoc-thai"},
                                                    new MenuItem{Title="Làm AFF",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/lam-aff"},
                                                        new MenuItem{Title="Đường thô nhập chuyền",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/duong-tho-nhap-chuyen"},
                                                           new MenuItem{Title="Đường non luyện",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/duong-non-luyen"},
                                                             new MenuItem{Title="Đường thô nhập kho",Icon=null,ParentId=nhaplieuphantich.Entity.Id,Url=nhaplieuphantich.Entity.Url +"/duong-tho-nhap-kho"},
                });
                await _dbContext.SaveChangesAsync();
                #endregion
                #endregion

                #region Quản trị hệ thống

                await _dbContext.MenuItems.AddRangeAsync(new List<MenuItem>
                {
                    new MenuItem{Title="Danh mục chức năng",Icon=null,ParentId=Quantrihethong.Entity.Id,Url=Quantrihethong.Entity.Url +"/danh-muc-chuc-nang"},
                       new MenuItem{Title="Công ty thành viên",Icon=null,ParentId=Quantrihethong.Entity.Id,Url=Quantrihethong.Entity.Url +"/cong-ty-thanh-vien"},
                          new MenuItem{Title="Quản lý nhóm",Icon=null,ParentId=Quantrihethong.Entity.Id,Url=Quantrihethong.Entity.Url +"/quan-ly-nhom"},
                               new MenuItem{Title="Xem vết ngươi dùng",Icon=null,ParentId=Quantrihethong.Entity.Id,Url=Quantrihethong.Entity.Url +"/xem-vet-nguoi-dung"},
                             new MenuItem{Title="Cấu hình chức năng",Icon=null,ParentId=Quantrihethong.Entity.Id,Url=Quantrihethong.Entity.Url +"/cau-hinh-chuc-nang"},
                                new MenuItem{Title="Cấu hình báo cáo",Icon=null,ParentId=Quantrihethong.Entity.Id,Url=Quantrihethong.Entity.Url +"/cau-hinh-bao-cao"},
                                    new MenuItem{Title="Cấu hình mùa vụ",Icon=null,ParentId=Quantrihethong.Entity.Id,Url=Quantrihethong.Entity.Url +"/cau-hinh-mua-vu"},
                });
                await _dbContext.SaveChangesAsync();
                #endregion

            }

            if (await _roleManager.Roles.CountAsync() == 0)
            {
                await _roleManager.CreateAsync(new ApplicationRole { Id = adminRoleId, Name = "Administrator" });
                await _roleManager.CreateAsync(new ApplicationRole { Id = userRoleId, Name = "User" });
            }

            if (await _dbContext.RoleMenus.CountAsync() == 0)
            {
                await _dbContext.RoleMenus.AddRangeAsync(new List<ApplicationRoleMenu>
                {
                    // Admin
                    new ApplicationRoleMenu {RoleId=adminRoleId, MenuId=1},
                    //new ApplicationRoleMenu {RoleId=adminRoleId, MenuId=2},
                    //new ApplicationRoleMenu {RoleId=adminRoleId, MenuId=3},
                    //new ApplicationRoleMenu {RoleId=adminRoleId, MenuId=4},
                    // User
                    new ApplicationRoleMenu {RoleId=userRoleId, MenuId=1},
                    //new ApplicationRoleMenu {RoleId=userRoleId, MenuId=2},

                });
                await _dbContext.SaveChangesAsync();
            }


            var samId = "C316633F-7DE3-48BE-A117-807AF8F7BE70";
            var ralphId = "102EBBD8-EFDA-462C-B7C2-1F5D88C80456";

            // Create Sam
            var sam = await _userManager.FindByEmailAsync("mffadmin@gmail.com");
            if (sam == null)
            {
                sam = new ApplicationUser
                {
                    Id = samId,
                    Email = "mffadmin@gmail.com",
                    UserName = "mffadmin@gmail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    NormalizedUserName = "MFF",
                    NormalizedEmail = "MFFADMIN@GMAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                await _userManager.CreateAsync(sam, "Password123!");
                await _userManager.AddToRoleAsync(sam, "Administrator");
            }

            // Create Ralph
            var ralph = await _userManager.FindByEmailAsync("user01@gmail.com");
            if (ralph == null)
            {
                ralph = new ApplicationUser
                {
                    Id = ralphId,
                    Email = "user01@gmail.com",
                    UserName = "user01@gmail.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "User 1",
                    NormalizedEmail = "USER01@GMAIL.COM",
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                await _userManager.CreateAsync(ralph, "Password456!");
                await _userManager.AddToRoleAsync(ralph, "User");
            }

            // If you want this by user, add the claims for each user.
            var samClaims = await _userManager.GetClaimsAsync(sam);
            if (samClaims.Count(y => y.Value == "View") == 0)
            {
                await _userManager.AddClaimsAsync(sam, new List<Claim>
                {
                    new Claim(1.ToString(), "View"),
                    new Claim(2.ToString(), "View"),
                    new Claim(3.ToString(), "View"),
                    new Claim(4.ToString(), "View")
                });
            }

            var ralphClaims = await _userManager.GetClaimsAsync(ralph);
            if (ralphClaims.Count(y => y.Value == "View") == 0)
            {
                await _userManager.AddClaimsAsync(ralph, new List<Claim>
                {
                    new Claim(1.ToString(), "View"),
                    new Claim(2.ToString(), "View")
                });

            }

            // Call the next delegate/middleware in the pipeline
            // await next(context);
        }
    }
}