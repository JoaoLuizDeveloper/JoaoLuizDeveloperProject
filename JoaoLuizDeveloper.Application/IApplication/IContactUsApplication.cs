using JoaoLuizDeveloper.Domain.Entity;

namespace JoaoLuizDeveloper.Application.Application
{
    public interface IContactUsApplication
    {
        Task<List<ContactUs>> GetAll();
        Task<ContactUs> GetOne(int id);
        Task<bool> Create(ContactUs newsLetter);
        Task<bool> Update(ContactUs newsLetter);
        Task<bool> Remove(int id);
    }
}