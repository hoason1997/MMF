using MFF.Data.SmartLab;
using MFF.ERPAPI.Factories;
using MFF.ERPAPI.Helper;
using MFF.ERPAPI.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

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
        { //    .AddCustomRepository<Blog, CustomBlogRepository>(););

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<TTCDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
           .AddUnitOfWork<TTCDBContext>();
            services.AddDbContext<BHSDNDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BHSDNConnection"))).AddUnitOfWork<BHSDNDBContext>();
            services.AddDbContext<BHSTNContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BHSTNConnection"))).AddUnitOfWork<BHSTNContext>();
            services.AddDbContext<NHSDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("NHSConnection"))).AddUnitOfWork<NHSDBContext>();
            services.AddDbContext<SECDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SECConnection"))).AddUnitOfWork<SECDBContext>();
            services.AddDbContext<PHANRANGDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("PHANRANGConnection"))).AddUnitOfWork<PHANRANGDBContext>();
            services.AddDbContext<BHSTADBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BHSTAConnection"))).AddUnitOfWork<BHSTADBContext>();
            services.AddDbContext<HAADBContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("HAAConnection"))).AddUnitOfWork<BHSTADBContext>();
            services.AddDbContext<TTCSDBContext>(options =>
     options.UseSqlServer(Configuration.GetConnectionString("TTCSConnection"))).AddUnitOfWork<BHSTADBContext>();
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
