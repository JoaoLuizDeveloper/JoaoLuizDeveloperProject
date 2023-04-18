using JoaoLuizDeveloper.Domain.Entity;

namespace JoaoLuizDeveloper.Application.Application
{
    public interface IAboutUsApplication
    {
        Task<List<AboutUs>> GetAll();
        Task<AboutUs> GetOne(int id);
        Task<bool> Create(AboutUs newsLetter);
        Task<bool> Update(AboutUs newsLetter);
        Task<bool> Remove(int id);        
    }
}