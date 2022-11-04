using System;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Bogus.DataSets;
using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.IntegrationTest.Config;
using JoaoLuizDeveloper.WebAPI;
using Newtonsoft.Json;
using Xunit;
using Assert = Xunit.Assert;

namespace JoaoLuizDeveloper.IntegrationTest.Metodos
{
    [Collection(nameof(IntegrationTestFixtureCollection))]
    public class AboutUsTest
    {
        private readonly IntegrationTestsFixture<StartupTests> _testsFixture;

        public AboutUsTest(IntegrationTestsFixture<StartupTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Get list of objects")]
        [Trait("Category", "GetAll")]
        public async Task AboutUs_RealizeGetAll_ShouldReturnListOfObjects()
        {
            // Arrange

            // Act
            var responseAPI = await _testsFixture.client.GetAsync(requestUri: "api/aboutUs/GetAll");

            var list = JsonConvert.DeserializeObject<List<AboutUs>>(await responseAPI.Content.ReadAsStringAsync());
            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.NotNull(list);
            Assert.NotEmpty(list);
            Assert.True(list.Count() > 0);
        }

        [Fact(DisplayName = "Get one object")]
        [Trait("Category", "Get")]
        public async Task AboutUs_RealizeObjectById_ShouldReturnOneObject()
        {
            // Arrange
            var id = 1;
            // Act
            var responseAPI = await _testsFixture.client.GetAsync(requestUri: $"api/aboutUs/Get/{id}");

            var objectResponse = JsonConvert.DeserializeObject<AboutUs>(await responseAPI.Content.ReadAsStringAsync());
            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.NotNull(objectResponse);
        }

        [Fact(DisplayName = "Add a new object with success")]
        [Trait("Category", "Create")]
        public async Task AddNewItem_NewAboutUs_ShouldReturnWithSuccess()
        {
            // Arrange
            var aboutUsNew = new AboutUs
            {
                Title = "New Title AboutUS ",
                Description = "Description AboutUs",
                DT_Insert = DateTime.Now,
                User_Insert = 1
            };

            // Act
            var responseAPI = await _testsFixture.client.PostAsJsonAsync("api/aboutUs/Create", aboutUsNew);
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }

        [Fact(DisplayName = "Update one object with success")]
        [Trait("Category", "Update")]
        public async Task UpdateItem_UpdateAboutUs_ShouldReturnWithSuccess()
        {
            // Arrange
            var aboutUsNew = new AboutUs
            {
                Id = 1,
                Title = "New Title AboutUS Updated",
                Description = "Description AboutUs Updated",
                DT_Insert = DateTime.Now,
                DT_Update = DateTime.Now,
                User_Insert = 1,
                User_Update = 1
            };

            var stringContentObject = new StringContent(JsonConvert.SerializeObject(aboutUsNew), Encoding.UTF8, "application/json");

            // Act

            var responseAPI = await _testsFixture.client.PatchAsync(requestUri: "api/aboutUs/Update", stringContentObject);
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }

        [Fact(DisplayName = "Remove an object")]
        [Trait("Category", "Remove")]
        public async Task RemoveItem_AboutUsExist_ShouldReturnWithSuccess()
        {
            // Arrange
            var id = 2;

            // Act
            var responseAPI = await _testsFixture.client.DeleteAsync($"api/aboutUs/Remove/{id}");
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }
    }
}