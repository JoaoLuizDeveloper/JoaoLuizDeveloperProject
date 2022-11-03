using JoaoLuizDeveloper.WebAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace JoaoLuizDeveloper.IntegrationTest.Config
{
    [CollectionDefinition(nameof(IntegrationTestFixtureCollection))]
    public class IntegrationTestFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupTests>>
    {

    }

    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly ConfigApp<TStartup> Factory;
        public HttpClient client;

        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
                //AllowAutoRedirect = true,
                //BaseAddress = new Uri("http://localhost"),
                //HandleCookies = true,
                //MaxAutomaticRedirections = 7
            };

            Factory = new ConfigApp<TStartup>();
            client = Factory.CreateClient(clientOptions);
        }

        public void Dispose()
        {
            client.Dispose();
            Factory.Dispose();
        }
    }
}