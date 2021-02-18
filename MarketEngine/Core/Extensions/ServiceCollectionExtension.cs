using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace MarketEngine.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureRazorEngineFolders(this IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("Web/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("Web/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
            });
        }
    }
}
