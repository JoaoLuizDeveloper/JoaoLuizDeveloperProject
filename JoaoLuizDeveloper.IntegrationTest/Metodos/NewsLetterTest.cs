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
    public class NewsLetterTest
    {
        private readonly IntegrationTestsFixture<StartupTests> _testsFixture;

        public NewsLetterTest(IntegrationTestsFixture<StartupTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Get list of objects")]
        [Trait("Category", "GetAll")]
        public async Task NewsLetter_RealizeGetAll_ShouldReturnListOfObjects()
        {
            // Arrange

            // Act
            var responseAPI = await _testsFixture.client.GetAsync(requestUri: "api/newsLetter/GetAll");

            var list = JsonConvert.DeserializeObject<List<NewsLetter>>(await responseAPI.Content.ReadAsStringAsync());
            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.NotNull(list);
            Assert.NotEmpty(list);
            Assert.True(list.Count() > 0);
        }

        [Fact(DisplayName = "Get one object")]
        [Trait("Category", "Get")]
        public async Task NewsLetter_RealizeObjectById_ShouldReturnOneObject()
        {
            // Arrange
            var id = 2;
            // Act
            var responseAPI = await _testsFixture.client.GetAsync(requestUri: $"api/newsLetter/Get/{id}");

            var objectResponse = JsonConvert.DeserializeObject<NewsLetter>(await responseAPI.Content.ReadAsStringAsync());
            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.NotNull(objectResponse);
        }

        [Fact(DisplayName = "Add a new object with success")]
        [Trait("Category", "Create")]
        public async Task AddNewItem_NewNewsLetter_ShouldReturnWithSuccess()
        {
            // Arrange
            var newsLetterNew = new NewsLetter
            {
                Title = "New Test2",
                Description = "Just a new Test2",
                DT_Insert = DateTime.Now,
                User_Insert = 1,
                Url = "new_test"
            };

            // Act
            var responseAPI = await _testsFixture.client.PostAsJsonAsync("api/newsLetter/Create", newsLetterNew);
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }

        [Fact(DisplayName = "Update one object with success")]
        [Trait("Category", "Update")]
        public async Task UpdateItem_UpdateNewsLetter_ShouldReturnWithSuccess()
        {
            // Arrange
            var newsLetterNew = new NewsLetter
            {
                Id = 5,
                Title = "New Test 5",
                Description = "Just a new Test5",
                DT_Insert = DateTime.Now,
                DT_Update = DateTime.Now,
                User_Insert = 1,
                User_Update = 1,
                Url = "new_test_5"
            };

            var stringContentObject = new StringContent(JsonConvert.SerializeObject(newsLetterNew), Encoding.UTF8, "application/json");

            // Act

            var responseAPI = await _testsFixture.client.PatchAsync(requestUri: "api/newsLetter/Update", stringContentObject);
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }

        [Fact(DisplayName = "Remove an object")]
        [Trait("Category", "Remove")]
        public async Task RemoveItem_NewsLetterExist_ShouldReturnWithSuccess()
        {
            // Arrange
            var id = 5;

            // Act
            var responseAPI = await _testsFixture.client.DeleteAsync($"api/newsLetter/Remove/{id}");
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }
    }
}