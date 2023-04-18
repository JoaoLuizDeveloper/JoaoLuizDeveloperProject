using JoaoLuizDeveloper.Domain.Entity;

namespace JoaoLuizDeveloper.Application.Application
{
    public interface IResumeApplication
    {
        Task<List<Resume>> GetAll();
        Task<Resume> GetOne(int id);
        Task<bool> Create(Resume newsLetter);
        Task<bool> Update(Resume newsLetter);
        Task<bool> Remove(int id);
    }
}