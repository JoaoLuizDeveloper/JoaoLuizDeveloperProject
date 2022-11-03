using JoaoLuizDeveloper.Application.Application;
using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace Metodos.UnitTest.Metodos
{
    public class ResumeUnit
    {
        private readonly Resume ObjectResume;

        public ResumeUnit()
        {
            ObjectResume = new Resume()
            {
                Id = 1,
                Title = "is simply dummy text of the printing and typesetting industry",
                Description = " is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"
            };
        }

        [Fact]
        public async Task CreateNewsLetter_TitleMorethanhundred_DontCreateAsync()
        {
            var getResumeRepository = new Mock<IResumeRepository>();
            var getResumeApplication = new ResumeApplication(getResumeRepository.Object);

            // Act
            await getResumeApplication.Create(ObjectResume);
            getResumeRepository.Verify(x => x.Add(ObjectResume).Result, Times.AtLeastOnce());            
        }


        [Fact]
        public async Task GetOne_StartingPage_ReturnOnlyOneObject()
        {
            var getResumeRepository = new Mock<IResumeRepository>();
            getResumeRepository.Setup(x => x.GetFirstOrDefault(It.IsAny<Expression<Func<Resume, bool>>>(), It.IsAny<string>()).Result).Returns(ObjectResume);
            var getResumeApplication = new ResumeApplication(getResumeRepository.Object);

            var idResume = 1;
            // Act
            var response = await getResumeApplication.GetOne(idResume);
            getResumeRepository.Verify(x => x.GetFirstOrDefault(It.IsAny<Expression<Func<Resume, bool>>>(), It.IsAny<string>()).Result, Times.Once);

            Assert.NotNull(response);
        }
    }
}