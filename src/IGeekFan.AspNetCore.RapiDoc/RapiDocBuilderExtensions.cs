using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace IGeekFan.AspNetCore.RapiDoc
{
    public static class RapiDocBuilderExtensions
    {
        public static IApplicationBuilder UseRapiDocUI(
             this IApplicationBuilder app,
             Action<RapiDocOptions> setupAction = null)
        {
            var options = new RapiDocOptions();
            if (setupAction != null)
            {
                setupAction(options);
            }
            else
            {
                options = app.ApplicationServices.GetRequiredService<IOptions<RapiDocOptions>>().Value;
            }
            
            app.UseMiddleware<RapiDocMiddleware>(options);

            return app;
        }
    }
}
