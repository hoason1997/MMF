using AutoMapper;
using MFF.Data.SmartLab;
using MFF.DTO.Entities.Identity;
using MFF.DTO.Middlewares;
using MFF.Infrastructure;
using MFF.Infrastructure.Configurations;
using MFF.Infrastructure.Mapping;
using MFF.Infrastructure.Services;
using MFF.WEB.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MFF.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.  
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabaseServices(services);
            ConfigureDefaultServices(services);
        }

        protected void ConfigureDefaultServices(IServiceCollection services)
        {
            services.AddAppConfig(Configuration);
            services.AddAutoMapper(typeof(IMappingProfile));
            services.AddTransient<ApplicationUserManager>();
            services.AddTransient<IRedisCacheService, RedisCacheService>();
            services.AddTransient<IMenuService, MenuService>();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
              .AddRoles<ApplicationRole>()
              .AddEntityFrameworkStores<SmartLabDBContext>()
              .AddRoleManager<RoleManager<ApplicationRole>>()
              .AddSignInManager<SignInManager<ApplicationUser>>()
              .AddUserManager<UserManager<ApplicationUser>>();

            services.AddTransient<IInitData, InitData>();
            //    services.AddTransient<IBanCanMiaService, BanCanMiaService>();          
            services.Configure<CookiePolicyOptions>(options => { options.CheckConsentNeeded = context => true; });
            services.AddControllersWithViews()
                .AddNewtonsoftJson();
            services.AddRazorPages();

            services.AddMvc(option => option.EnableEndpointRouting = false);


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                //.AddFacebook(facebookOptions =>
                //    {
                //        facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                //        facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                //    })
                //.AddGoogle(googleOptions =>
                //    {
                //        IConfigurationSection googleAuthNSection =
                //        Configuration.GetSection("Authentication:Google");
                //        googleOptions.ClientId = googleAuthNSection["ClientId"];
                //        googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                //    })
                //.AddMicrosoftAccount(microsoftOptions =>
                //    {
                //        microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                //        microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
                //    })
                .AddCookie(config =>
                  {
                      config.Cookie.Name = "UserLoginCookie";
                      config.LoginPath = "/Account/Login";
                  });
        }

        // We have to override this message in our TestStartup, because we want to inject our own database providers
        protected virtual void ConfigureDatabaseServices(IServiceCollection services)
        {
            #region SQLite
            //services.AddDbContext<SmartLabDB>(options =>
            //    options.UseSqlite(
            //        Configuration.GetConnectionString("DefaultConnection"),
            //        builder => builder.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name)
            //    ));
            #endregion

            services.AddDbContext<SmartLabDBContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //        services.AddDbContext<SmartLabDB>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("SmartLabConnect")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseDeveloperExceptionPage();
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthorization();
            loggerFactory.AddSerilog();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{area=SmartLab}/{controller=Test}/{action=testchart}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=SmartLab}/{controller=Test}/{action=testchart}");

                //endpoints.MapControllerRoute(
                //    name: "AVC",
                //    pattern: "{area=SmartLab}/{controller=Demo2}/{action=Index}");

                endpoints.MapRazorPages();
            });
        }
    }
}
