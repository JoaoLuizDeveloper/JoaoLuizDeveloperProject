using JoaoLuizDeveloper.Application.Application;
using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace Metodos.UnitTest.Metodos
{
    public class NewsLetterUnit
    {
        private readonly NewsLetter ObjectNews;
        private readonly List<NewsLetter> ListNews;

        public NewsLetterUnit()
        {
            ObjectNews = new NewsLetter()
            {
                Title = "is simply dummy text of the printing and typesetting industry",
                Description = " is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Image = "",
                Url = "is-simply-dummy-text-of-the-printing-and-typesetting-industry"
            };

            ListNews = new List<NewsLetter>()
            {
                new NewsLetter()
                {
                    Id = 1,
                    Title = "Novidades sobre .net",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    DT_Insert = DateTime.Now,
                    Image = "",
                    Url = "novidades-sobre-net"
                },
                new NewsLetter()
                {
                    Id = 2,
                    Title = "Falando sobre criptoMoedas",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    DT_Insert = DateTime.Now,
                    Image = "",
                    Url = "falando-sobre-criptomoedas"
                },
                new NewsLetter()
                {
                    Id = 3,
                    Title = "Dicas sobre Visual studio",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    DT_Insert = DateTime.Now,
                    Image = "",
                    Url = "dicas-sobre-visual-studio"
                },
                new NewsLetter()
                {
                    Id = 4,
                    Title = "Dicas sobre javascript",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    DT_Insert = DateTime.Now,
                    Image = "",
                    Url = "dicas-sobre-javascript"
                },
            };
        }

        [Fact]
        public async Task CreateNewsLetter_TitleMorethanhundred_DontCreateAsync()
        {
            var getNewsLetterRepository = new Mock<INewsLetterRepository>();

            var getNewsLetterApplication = new NewsLetterApplication(getNewsLetterRepository.Object);

            // Act
            await getNewsLetterApplication.Create(ObjectNews);

            getNewsLetterRepository.Verify(x => x.Add(ObjectNews).Result, Times.AtLeastOnce());            
        }
        
        [Fact]
        public async Task GetAllNewsLetter_OrderByDesc_ShowAllDatasAsync()
        {
            var getNewsLetterRepository = new Mock<INewsLetterRepository>();
            getNewsLetterRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<NewsLetter, bool>>>(), null, It.IsAny<string>()).Result).Returns(ListNews);

            var getNewsLetterApplication = new NewsLetterApplication(getNewsLetterRepository.Object);

            // Act
            var response = await getNewsLetterApplication.GetAll();

            getNewsLetterRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<NewsLetter, bool>>>(), null, It.IsAny<string>()).Result, Times.Once);
            Assert.NotNull(response);
            Assert.NotEmpty(response);
            Assert.True(response.Count() == 4);
        }
        
        [Fact]
        public async Task GetURL_CreatingObject_ReturnURLPattern()
        {
            var getNewsLetterRepository = new Mock<INewsLetterRepository>();
            var getNewsLetterApplication = new NewsLetterApplication(getNewsLetterRepository.Object);

            // Act
            var response = getNewsLetterApplication.DefineURL(ObjectNews.Title);

            Assert.NotNull(response);
            Assert.NotEmpty(response);
            Assert.Equal("is-simply-dummy-text-of-the-printing-and-typesetting-industry", response);
        }
    }
}