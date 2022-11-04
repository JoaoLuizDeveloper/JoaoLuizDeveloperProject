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
    public class ContactUsTest
    {
        private readonly IntegrationTestsFixture<StartupTests> _testsFixture;

        public ContactUsTest(IntegrationTestsFixture<StartupTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Get list of objects")]
        [Trait("Category", "GetAll")]
        public async Task ContactUs_RealizeGetAll_ShouldReturnListOfObjects()
        {
            // Arrange

            // Act
            var responseAPI = await _testsFixture.client.GetAsync(requestUri: "api/contactUs/GetAll");

            var list = JsonConvert.DeserializeObject<List<ContactUs>>(await responseAPI.Content.ReadAsStringAsync());
            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.NotNull(list);
            Assert.NotEmpty(list);
            Assert.True(list.Count() > 0);
        }

        [Fact(DisplayName = "Get one object")]
        [Trait("Category", "Get")]
        public async Task ContactUs_RealizeObjectById_ShouldReturnOneObject()
        {
            // Arrange
            var id = 1;
            // Act
            var responseAPI = await _testsFixture.client.GetAsync(requestUri: $"api/contactUs/Get/{id}");

            var objectResponse = JsonConvert.DeserializeObject<ContactUs>(await responseAPI.Content.ReadAsStringAsync());
            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.NotNull(objectResponse);
        }

        [Fact(DisplayName = "Add a new object with success")]
        [Trait("Category", "Create")]
        public async Task AddNewItem_NewContactUs_ShouldReturnWithSuccess()
        {
            // Arrange
            var contactUsNew = new ContactUs
            {
                Subject = "New Subject ContactUs",
                Description = "Description for ContactUs",
                DT_Insert = DateTime.Now,
                User_Insert = 1,
                Email = "joao.domingues@luby.software",
                Phone = "(24) 99832-9477"
            };

            // Act
            var responseAPI = await _testsFixture.client.PostAsJsonAsync("api/contactUs/Create", contactUsNew);
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }

        [Fact(DisplayName = "Update one object with success")]
        [Trait("Category", "Update")]
        public async Task UpdateItem_UpdateContactUs_ShouldReturnWithSuccess()
        {
            // Arrange
            var contactUsNew = new ContactUs
            {
                Id = 1,
                Subject = "New Subject ContactUs Updated",
                Description = "Description for ContactUs Updated",
                DT_Insert = DateTime.Now,
                User_Insert = 1,
                Email = "joao.domingues@luby.software",
                Phone = "(24) 99832-9477"
            };

            var stringContentObject = new StringContent(JsonConvert.SerializeObject(contactUsNew), Encoding.UTF8, "application/json");

            // Act

            var responseAPI = await _testsFixture.client.PatchAsync(requestUri: "api/contactUs/Update", stringContentObject);
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }

        [Fact(DisplayName = "Remove an object")]
        [Trait("Category", "Remove")]
        public async Task RemoveItem_ContactUsExist_ShouldReturnWithSuccess()
        {
            // Arrange
            var id = 2;

            // Act
            var responseAPI = await _testsFixture.client.DeleteAsync($"api/contactUs/Remove/{id}");
            var objectResponse = JsonConvert.DeserializeObject<bool>(await responseAPI.Content.ReadAsStringAsync());

            // Assert
            responseAPI.EnsureSuccessStatusCode();
            Assert.True(objectResponse);
        }
    }
}