using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace JoaoLuizDeveloper.IntegrationTest
{
    [TestClass]
    public class Tests
    {
        private HttpClient _httpClient;
        public Tests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        public async Task DefaultRoute_ReturnsHelloWorld()
        {
            var response = await _httpClient.GetAsync("");

            var stringResult = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("Hello World!", stringResult);
        }

        [TestMethod]
        public async Task Sum_Returns16For10And6() 
        {
            var response = await _httpClient.GetAsync("/sum?n1=10&n2=6");
            var stringResult = await response.Content.ReadAsStringAsync();
            var intResult = int.Parse(stringResult);

            Assert.AreEqual(16, intResult);
        }
    }
}