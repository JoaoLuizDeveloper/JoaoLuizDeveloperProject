using JoaoLuizDeveloper.Domain.Entity;

namespace JoaoLuizDeveloper.Application.Application
{
    public interface INewsLetterApplication
    {
        Task<List<NewsLetter>> GetAll();
        Task<NewsLetter> GetOne(int id);
        Task<bool> Create(NewsLetter newsLetter);
        Task<bool> Update(NewsLetter newsLetter);
        Task<bool> Remove(int id);
        string DefineURL(string title);
    }
}