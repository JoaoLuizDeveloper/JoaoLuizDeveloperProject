using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;

namespace JoaoLuizDeveloper.Application.Application
{
    public class ResumeApplication : IResumeApplication
    {
        private readonly IResumeRepository _resumeRepository;
        public ResumeApplication(IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
        }

        public async Task<List<Resume>> GetAll()
        {
            return await _resumeRepository.GetAll();
        }

        public async Task<Resume> GetOne(int id)
        {
            return await _resumeRepository.Get(id);
        }

        public async Task<bool> Create(Resume resume)
        {
            return await _resumeRepository.Add(resume);
        }

        public async Task<bool> Update(Resume resume)
        {
            return await _resumeRepository.Update(resume);
        }

        public async Task<bool> Remove(int id)
        {
            return await _resumeRepository.Remove(id);
        }
    }
}