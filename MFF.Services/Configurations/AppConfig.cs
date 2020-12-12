using MFF.Infrastructure.Repositories;
using MFF.Infrastructure.Services;
using MFF.Infrastructure.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MFF.Infrastructure.Configurations
{
    /// <summary>
    /// AppConfig
    /// </summary>
    public static class AppConfig
    {
        /// <summary>
        /// AddAppConfig
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddAppConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //  services.AddScoped<IAccountService, AccountService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddTransient<IRedisCacheService, RedisCacheService>();
            services.AddTransient<IService, Service>();
            services.AddTransient<ICauHoiService, CauHoiService>();
            services.AddHttpContextAccessor();
            ////services.AddScoped<IExecuteSql, ExecuteSql>();
            // using reflection register serivces
            //services.Scan(x =>
            //{
            //    var entryAssembly = Assembly.GetEntryAssembly();
            //    var referencedAssemblies = entryAssembly.GetReferencedAssemblies().Select(Assembly.Load);
            //    var assemblies = new List<Assembly> { entryAssembly }.Concat(referencedAssemblies);
            //    x.FromAssemblies(assemblies).AddClasses(classes => classes.AssignableTo(typeof(IService))).AsImplementedInterfaces().WithScopedLifetime();
            //});

            ////services.AddTransient<IMailService, MailService>();
            ////services.AddTransient<IRedisCacheService, RedisCacheService>();
            //    services.AddTransient<IFileService, FileService>();
            //services.AddTransient<ISettingService, SettingService>();
            //services.AddTransient<IBannerService, BannerService>();
            //services.AddTransient<IFeedbackService, FeedbackService>();
            //services.AddWebMarkupMin(
            //    options =>
            //    {
            //        options.AllowMinificationInDevelopmentEnvironment = true;
            //        options.AllowCompressionInDevelopmentEnvironment = true;
            //    })
            //    .AddHtmlMinification(
            //        options =>
            //        {
            //            options.MinificationSettings.RemoveRedundantAttributes = true;
            //            options.MinificationSettings.RemoveHttpProtocolFromAttributes = false;
            //            options.MinificationSettings.RemoveHttpsProtocolFromAttributes = false;
            //        })
            //    .AddHttpCompression();
            //services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Fastest);
            //services.AddResponseCompression();
            //services.AddResponseCaching();
            //services.AddHttpCacheHeaders(
            //    (expirationModelOptions) =>
            //    {
            //        expirationModelOptions.MaxAge = 86400;
            //    },
            //    (validationModelOptions) =>
            //    {
            //        validationModelOptions.MustRevalidate = false;
            //    });
        }
    }
}
