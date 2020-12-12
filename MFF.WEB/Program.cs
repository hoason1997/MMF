using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace MFF.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args)
            //.Build()
            //.MigrateDbContext<MFFDbContext>(serviceProvider =>
            //{
            //    var context = serviceProvider.GetRequiredService<MFFDbContext>();
            //    if (!context.MFFItem.Any())
            //    {
            //        context.MFFItem.Add(new MFFItem() { Id = Guid.NewGuid(), Name = "Item 1" });
            //        context.MFFItem.Add(new MFFItem() { Id = Guid.NewGuid(), Name = "Item 2" });
            //        context.SaveChanges();
            //    }
            //})
            //.Run();

            try
            {
                CreateHostBuilder(args)
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
                    Host.CreateDefaultBuilder(args)
                        .ConfigureWebHostDefaults(configure =>
                        {
                            configure.UseStartup<Startup>();
                        }).UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                       .ReadFrom.Configuration(hostingContext.Configuration));
    }
}
