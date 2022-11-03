using JoaoLuizDeveloper.Application.Application;
using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace Metodos.UnitTest.Metodos
{
    public class AboutUsUnit
    {
        private readonly AboutUs ObjectAboutUs;
        private readonly List<AboutUs> ListAboutUs;

        public AboutUsUnit()
        {
            ObjectAboutUs = new AboutUs()
            {
                Id = 1,
                Title = "is simply dummy text of the printing and typesetting industry",
                Description = " is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Image = ""
            };

            ListAboutUs = new List<AboutUs>() 
            { 
                ObjectAboutUs 
            };
        }

        [Fact]
        public async Task CreateAboutUs_TitleMorethanhundred_DontCreateAsync()
        {
            var getAboutUsRepository = new Mock<IAboutUsRepository>();            
            var getAboutUsApplication = new AboutUsApplication(getAboutUsRepository.Object);

            // Act
            await getAboutUsApplication.Create(ObjectAboutUs);
            getAboutUsRepository.Verify(x => x.Add(ObjectAboutUs).Result, Times.AtLeastOnce());            
        }
        
        [Fact]
        public async Task GetOne_StartingPage_ReturnOnlyOneObject()
        {
            var getAboutUsRepository = new Mock<IAboutUsRepository>();
            getAboutUsRepository.Setup(x => x.GetFirstOrDefault(It.IsAny<Expression<Func<AboutUs, bool>>>(), It.IsAny<string>()).Result).Returns(ObjectAboutUs);
            var getAboutUsApplication = new AboutUsApplication(getAboutUsRepository.Object);
            var idaboutUs = 1;
            // Act
            var response = await getAboutUsApplication.GetOne(idaboutUs);
            getAboutUsRepository.Verify(x => x.GetFirstOrDefault(It.IsAny<Expression<Func<AboutUs, bool>>>(), It.IsAny<string>()).Result, Times.Once);
            
            Assert.NotNull(response);
        }
    }
}