using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;
using JoaoLuizDeveloper.Infrastructure.Repository;
using System.Text.RegularExpressions;

namespace JoaoLuizDeveloper.Application.Application
{
    public class NewsLetterApplication : INewsLetterApplication
    {
        private readonly INewsLetterRepository _newsLetterRepository;
        public NewsLetterApplication(INewsLetterRepository newsLetterRepository)
        {
            _newsLetterRepository = newsLetterRepository;
        }

        public async Task<List<NewsLetter>> GetAll()
        {
            return await _newsLetterRepository.GetAll();
        }

        public async Task<NewsLetter> GetOne(int id)
        {
            return await _newsLetterRepository.Get(id);
        }

        public async Task<bool> Create(NewsLetter newsLetter)
        {
            if (string.IsNullOrEmpty(newsLetter.Url))
            {
                newsLetter.Url = DefineURL(newsLetter.Title);
            }

            return await _newsLetterRepository.Add(newsLetter);
        }

        public async Task<bool> Update(NewsLetter newsLetter)
        {
            return await _newsLetterRepository.Update(newsLetter);
        }

        public async Task<bool> Remove(int id)
        {
            return await _newsLetterRepository.Remove(id);
        }
                
        public string DefineURL(string title)
        {
            return Regex.Replace(title, "[^0-9a-zA-Z]+", "-").ToLower();
        }
    }
}