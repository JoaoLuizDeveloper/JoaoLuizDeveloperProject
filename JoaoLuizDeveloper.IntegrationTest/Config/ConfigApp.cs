using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace JoaoLuizDeveloper.IntegrationTest.Config
{
    public class ConfigApp<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<TProgram>();
            builder.UseEnvironment("Testing");
        }
    }
}
