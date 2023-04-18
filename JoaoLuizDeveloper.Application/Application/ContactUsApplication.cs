using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;
using JoaoLuizDeveloper.Infrastructure.Repository;
using System.Text.RegularExpressions;

namespace JoaoLuizDeveloper.Application.Application
{
    public class ContactUsApplication : IContactUsApplication
    {
        private readonly IContactUsRepository _contactUsRepository;
        public ContactUsApplication(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public async Task<List<ContactUs>> GetAll()
        {
            return await _contactUsRepository.GetAll();
        }

        public async Task<ContactUs> GetOne(int id)
        {
            return await _contactUsRepository.Get(id);
        }

        public async Task<bool> Create(ContactUs contactUs)
        {
            return await _contactUsRepository.Add(contactUs);
        }

        public async Task<bool> Update(ContactUs contactUs)
        {
            return await _contactUsRepository.Update(contactUs);
        }

        public async Task<bool> Remove(int id)
        {
            return await _contactUsRepository.Remove(id);
        }
    }
}