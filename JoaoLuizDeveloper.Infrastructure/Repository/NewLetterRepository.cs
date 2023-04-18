using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;

namespace JoaoLuizDeveloper.Infrastructure.Repository
{
    public class NewLetterRepository : RepositoryBase<NewsLetter>, INewsLetterRepository
    {
        #region Construtor
        private readonly ApplicationDbContext _db;
        public NewLetterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
        #endregion
    }
}