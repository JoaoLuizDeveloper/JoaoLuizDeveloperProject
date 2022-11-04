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
    public class ResumeTest
    {
        private readonly IntegrationTestsFixture<StartupTests> _testsFixture;

        public ResumeTest(IntegrationTestsFixture<StartupTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Get list of objects")]
        [Trait("Category", "GetAll")]
        public async Task Resume_RealizeGetAll_ShouldReturnListOfObjects()
        {
            // Arrange

            // Act
            var responseAPI = await _testsFixture.client.GetAsync(requestUri: "api/resume/GetAll");

            var list = JsonConvert.DeserializeObject<List<Resume>>(await responseAPI.Content.ReadAsStringAsync());
            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.NotNull(list);
            Assert.NotEmpty(list);
            Assert.True(list.Count() > 0);
        }

        [Fact(DisplayName = "Get one object")]
        [Trait("Category", "Get")]
        public async Task Resume_RealizeObjectById_ShouldReturnOneObject()
        {
            // Arrange
            var id = 1;
            // Act
            var responseAPI = await _testsFixture.client.GetAsync(requestUri: $"api/resume/Get/{id}");

            var objectResponse = JsonConvert.DeserializeObject<Resume>(await responseAPI.Content.ReadAsStringAsync());
            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.NotNull(objectResponse);
        }

        [Fact(DisplayName = "Add a new object with success")]
        [Trait("Category", "Create")]
        public async Task AddNewItem_NewResume_ShouldReturnWithSuccess()
        {
            // Arrange
            var resumeNew = new Resume
            {
                Title = "New Resume",
                Description = "Description for Resume",
                DT_Insert = DateTime.Now,
                User_Insert = 1
            };

            // Act
            var responseAPI = await _testsFixture.client.PostAsJsonAsync("api/resume/Create", resumeNew);
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }

        [Fact(DisplayName = "Update one object with success")]
        [Trait("Category", "Update")]
        public async Task UpdateItem_UpdateResume_ShouldReturnWithSuccess()
        {
            // Arrange
            var resumeNew = new Resume
            {
                Id = 1,
                Title = "New Resume Updated",
                Description = "Description for Resume Updated",
                DT_Insert = DateTime.Now,
                DT_Update = DateTime.Now,
                User_Insert = 1,
                User_Update = 1
            };

            var stringContentObject = new StringContent(JsonConvert.SerializeObject(resumeNew), Encoding.UTF8, "application/json");

            // Act

            var responseAPI = await _testsFixture.client.PatchAsync(requestUri: "api/resume/Update", stringContentObject);
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }

        [Fact(DisplayName = "Remove an object")]
        [Trait("Category", "Remove")]
        public async Task RemoveItem_ResumeExist_ShouldReturnWithSuccess()
        {
            // Arrange
            var id = 2;

            // Act
            var responseAPI = await _testsFixture.client.DeleteAsync($"api/resume/Remove/{id}");
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }
    }
}