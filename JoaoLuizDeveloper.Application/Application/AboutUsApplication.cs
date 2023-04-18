using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;

namespace JoaoLuizDeveloper.Application.Application
{
    public class AboutUsApplication : IAboutUsApplication
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        public AboutUsApplication(IAboutUsRepository aboutUsRepository)
        {
            _aboutUsRepository = aboutUsRepository;
        }

        public async Task<List<AboutUs>> GetAll()
        { 
            return await _aboutUsRepository.GetAll();
        }
        
        public async Task<AboutUs> GetOne(int id)
        { 
            return await _aboutUsRepository.Get(id);
        }
        
        public async Task<bool> Create(AboutUs aboutUs)
        {
            return await _aboutUsRepository.Add(aboutUs);
        }
        
        public async Task<bool> Update(AboutUs aboutUs)
        {
            return await _aboutUsRepository.Update(aboutUs);
        }
        
        public async Task<bool> Remove(int id)
        {
            return await _aboutUsRepository.Remove(id);
        }
    }
}