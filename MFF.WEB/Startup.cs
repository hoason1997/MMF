using AutoMapper;
using MFF.Data.NHCH;
using MFF.DTO.Middlewares;
using MFF.Infrastructure.Configurations;
using MFF.Infrastructure.Mapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
       //    services.AddTransient<ICauHoiService, CauHoiService>();
            services.AddAppConfig(Configuration);
            services.AddAutoMapper(typeof(IMappingProfile));
         //   services.AddAutoMapperConfig();
            services.Configure<CookiePolicyOptions>(options => { options.CheckConsentNeeded = context => true; });
            //services.AddDefaultIdentity<User>()
            //    .AddDefaultUI()
            //    .AddUserStore<MFFUserStore>();
            services.AddControllersWithViews()
                .AddNewtonsoftJson();
            // services.AddRazorPages();
            //services.AddScoped<IMFFItemService, MFFItemService>();

            services.AddMvc(option => option.EnableEndpointRouting = false);


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddFacebook(facebookOptions =>
                    {
                        facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                        facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                    })
                .AddGoogle(googleOptions =>
                    {
                        IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");
                        googleOptions.ClientId = googleAuthNSection["ClientId"];
                        googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                    })
                .AddMicrosoftAccount(microsoftOptions =>
                    {
                        microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                        microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
                    })
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
            //services.AddDbContext<MFFDbContext>(options =>
            //    options.UseSqlite(
            //        Configuration.GetConnectionString("DefaultConnection"),
            //        builder => builder.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name)
            //    ));
            #endregion

             //   services.AddDbContext<CauHoiPhapLyDB>(options =>
        //    options.UseSqlServer(Configuration.GetConnectionString("NHCHConnection")));
            services.AddDbContext<CauHoiDB>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("NHCHConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }  
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
            app.UseHttpsRedirection();
            app.UseStaticFiles();
        
            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
               // endpoints.MapControllerRoute("default", "{controller=CauHoi}/{action=Index}/");
                // endpoints.MapRazorPages();

                endpoints.MapAreaControllerRoute(
                 name: "NHCH",
                 areaName: "NHCH",
                 pattern: "NHCH/{controller=CauHoi}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=NHCH}/{controller=CauHoi}/{action=Index}");

                endpoints.MapRazorPages();
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=NhanVien}/{action=Index}");
            //});            
        }
    }
}
