using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
#if NETSTANDARD2_0
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
#endif

namespace IGeekFan.AspNetCore.RapiDoc
{
    public static class RapiDocBuilderExtensions
    {
        /// <summary>
        /// Register the RapiDocUI middleware with provided options
        /// </summary>
        public static IApplicationBuilder UseRapiDocUI(this IApplicationBuilder app, RapiDocOptions options)
        {
            return app.UseMiddleware<RapiDocMiddleware>(options);
        }
        /// <summary>
        /// Register the RapiDocUI middleware with optional setup action for DI-injected options
        /// </summary>
        public static IApplicationBuilder UseRapiDocUI(
             this IApplicationBuilder app,
             Action<RapiDocOptions> setupAction = null)
        {
            RapiDocOptions options;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<RapiDocOptions>>().Value;
                setupAction?.Invoke(options);
            }

            // To simplify the common case, use a default that will work with the SwaggerMiddleware defaults
            if (options.ConfigObject.Urls == null)
            {
                var hostingEnv = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
                options.ConfigObject.Urls = new[] { new UrlDescriptor { Name = $"{hostingEnv.ApplicationName} v1", Url = "v1/swagger.json" } };
            }
            return app.UseRapiDocUI(options);
        }
    }
}
