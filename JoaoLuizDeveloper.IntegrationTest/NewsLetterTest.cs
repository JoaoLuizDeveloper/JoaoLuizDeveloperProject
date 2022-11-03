using System;
using System.Net.Http;
using System.Threading.Tasks;
using JoaoLuizDeveloper.IntegrationTest.Config;
using JoaoLuizDeveloper.WebAPI;
using Xunit;

namespace JoaoLuizDeveloper.IntegrationTest
{
    /// <summary>
    /// [TestCaseOrderer("Features.Tests.PriorityOrderer", "Features.Tests")]
    /// </summary>
    [Collection(nameof(IntegrationTestFixtureCollection))]
    public class NewsLetterTest
    {
        private readonly IntegrationTestsFixture<StartupTests> _testsFixture;

        public NewsLetterTest(IntegrationTestsFixture<StartupTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Realize create with success")]
        //[Trait("Category", "Create a New Object")]
        public async Task NewsLetter_RealizeCreate_ShouldCreateANewNewsLetter()
        {
            // Arrange
            var initialResponse = await _testsFixture.client.GetAsync(requestUri: "api/newsLetter/GetAll");
            initialResponse.EnsureSuccessStatusCode();
            // Act

            // Assert
        }
    }
}