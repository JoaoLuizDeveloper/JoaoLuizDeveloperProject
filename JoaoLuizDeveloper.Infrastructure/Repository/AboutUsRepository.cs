using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;

namespace JoaoLuizDeveloper.Infrastructure.Repository
{
    public class AboutUsRepository : RepositoryBase<AboutUs>, IAboutUsRepository
    {
        #region Construtor
        private readonly ApplicationDbContext _db;
        public AboutUsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
        #endregion
    }
}