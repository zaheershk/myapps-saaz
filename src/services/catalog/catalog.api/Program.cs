using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;
using saaz.Catalog.Data;

namespace saaz.Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            //seed-data
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var catalogContext = services.GetRequiredService<CatalogDbContext>();
                    CatalogDbContextSeed.SeedAsync(catalogContext, loggerFactory).Wait();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred while seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration((ctx, builder) =>
                //{
                //    var config = builder.Build();
                //    var keyVaultEndpoint = config["KeyVault:BaseUrl"];
                //    if (!string.IsNullOrEmpty(keyVaultEndpoint))
                //    {
                //        var azureServiceTokenProvider = new AzureServiceTokenProvider();
                //        var keyVaultClient = new KeyVaultClient(
                //            new KeyVaultClient.AuthenticationCallback(
                //                azureServiceTokenProvider.KeyVaultTokenCallback));
                //        builder.AddAzureKeyVault(
                //            keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
                //    }
                //})
                // .ConfigureLogging((ctx, logging) =>
                // {
                //     logging.AddConfiguration(ctx.Configuration.GetSection("Logging"));
                //     logging.AddConsole();
                //     logging.AddDebug();
                // })
                .UseStartup<Startup>()
                .Build();
    }
}
