using JoaoLuizDeveloper.Application.Application;
using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace Metodos.UnitTest.Metodos
{
    public class ContactUsUnit
    {
        private readonly ContactUs ObjectContactUs;
        private readonly List<ContactUs> ListContactUs;

        public ContactUsUnit()
        {
            ObjectContactUs = new ContactUs()
            {
                Id = 1,
                Subject = "is simply dummy text of the printing and typesetting industry",
                Description = " is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Email = "",
                Phone = "",
                file = ""
            };

            ListContactUs = new List<ContactUs>()
            {
                new ContactUs()
                {
                    Id = 1,
                    Subject = "is simply dummy text of the printing and typesetting industry",
                    Description = " is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Email = "",
                    Phone = "",
                    file = ""
                },
                new ContactUs()
                {
                    Id = 2,
                    Subject = "is simply dummy text of the printing and typesetting industry",
                    Description = " is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Email = "",
                    Phone = "",
                    file = ""
                },
                new ContactUs()
                {
                    Id = 3,
                    Subject = "is simply dummy text of the printing and typesetting industry",
                    Description = " is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Email = "",
                    Phone = "",
                    file = ""
                },
                new ContactUs()
                {
                    Id = 4,
                    Subject = "is simply dummy text of the printing and typesetting industry",
                    Description = " is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Email = "",
                    Phone = "",
                    file = ""
                },
            };
        }

        [Fact]
        public async Task CreateContactUs_TitleMorethanhundred_DontCreateAsync()
        {
            var getContactUsRepository = new Mock<IContactUsRepository>();

            var getContactUsApplication = new ContactUsApplication(getContactUsRepository.Object);

            // Act
            await getContactUsApplication.Create(ObjectContactUs);

            getContactUsRepository.Verify(x => x.Add(ObjectContactUs).Result, Times.AtLeastOnce());            
        }
        
        [Fact]
        public async Task GetAllContactUs_OrderByDesc_ShowAllDatasAsync()
        {
            var getContactUsRepository = new Mock<IContactUsRepository>();
            getContactUsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<ContactUs, bool>>>(), null, It.IsAny<string>()).Result).Returns(ListContactUs);

            var getContactUsApplication = new ContactUsApplication(getContactUsRepository.Object);

            // Act
            var response = await getContactUsApplication.GetAll();

            getContactUsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<ContactUs, bool>>>(), null, It.IsAny<string>()).Result, Times.Once);
            Assert.NotNull(response);
            Assert.NotEmpty(response);
            Assert.True(response.Count() == 4);
        }
    }
}