﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace GetRapidoc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = AppStartup();

            var service = ActivatorUtilities.CreateInstance<App>(host.Services);

            await service.RunAsync(args);

        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            // Check the current directory that the application is running on 
            // Then once the file 'appsetting.json' is found, we are adding it.
            // We add env variables, which can override the configs in appsettings.json
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                ;
        }

        static IHost AppStartup()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            BuildConfig(builder);
            IConfigurationRoot configuration = builder.Build();
            // Specifying the configuration for serilog
            Log.Logger = new LoggerConfiguration() // initiate the logger configuration
                            .ReadFrom.Configuration(configuration) // connect serilog to our configuration folder
                            .Enrich.FromLogContext() //Adds more information to our logs from built in Serilog 
                            .CreateLogger(); //initialise the logger

            Log.Logger.Information("Application Starting");


            var host = Host.CreateDefaultBuilder() 
                        .ConfigureServices((context, services) =>
                        { 
                            services.Configure<AppOption>(configuration.GetSection(AppOption.Name));
                            services.AddTransient<App>(); 
                            services.AddHttpClient();
                        })
                        .UseSerilog() 
                        .Build(); 

            return host;
        }
    }
}
