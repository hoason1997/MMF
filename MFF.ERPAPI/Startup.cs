using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Serilog;
using MFF.ERPAPI.Database;
using MFF.ERPAPI.Factories;
using MFF.ERPAPI.Middleware;

namespace MFF.ERPAPI
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
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //services.AddTransient<ILSXService, LSXService>();
            //services.AddTransient<ITTTieuHaoService, TTTieuHaoService>();
            //   services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //   services.AddScoped<IUnitOfWork, UnitOfWork>();
            //  services.AddAutoMapper(typeof(IMappingProfile));
            services.AddDbContext<BHSTADBContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
           .AddUnitOfWork<BHSTADBContext>();
            //    .AddCustomRepository<Blog, CustomBlogRepository>(););

            services.AddDbContext<TTCSDBContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))).AddUnitOfWork<TTCSDBContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseAuthorization();
            loggerFactory.AddSerilog();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
