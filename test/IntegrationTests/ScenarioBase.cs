using GoodCode.API;
using GoodCode.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace IntegrationTests
{
    public class ScenarioBase
    {
        protected TestServer CreateServer()
        {            
            var webHostBuilder = new WebHostBuilder()
                    .UseStartup(typeof(Startup))
                    .UseKestrel()
                    .UseConfiguration(GetConfiguration())
                    .ConfigureAppConfiguration((builderContext, config) =>
                    {
                        config
                        .AddInMemoryCollection(new Dictionary<string, string>
                        {
                            { "isTest", "true"}
                        });
                    });

            var testServer = new TestServer(webHostBuilder);

            var services = (IServiceScopeFactory)testServer.Host.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            }

            return testServer;
        }

        protected IConfiguration GetConfiguration() => new ConfigurationBuilder()
                .AddUserSecrets(typeof(Startup).GetTypeInfo().Assembly)
                .Build();
    }    
}
