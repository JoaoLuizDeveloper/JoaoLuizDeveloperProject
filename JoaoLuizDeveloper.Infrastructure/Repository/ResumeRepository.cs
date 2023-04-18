using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;

namespace JoaoLuizDeveloper.Infrastructure.Repository
{
    public class ResumeRepository : RepositoryBase<Resume>, IResumeRepository
    {
        #region Construtor
        private readonly ApplicationDbContext _db;
        public ResumeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
        #endregion
    }
}