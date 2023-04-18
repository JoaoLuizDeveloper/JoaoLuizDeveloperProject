using JoaoLuizDeveloper.Domain.Entity;
using JoaoLuizDeveloper.Domain.Interfaces;

namespace JoaoLuizDeveloper.Infrastructure.Repository
{
    public class ContactUsRepository : RepositoryBase<ContactUs>, IContactUsRepository
    {
        #region Construtor
        private readonly ApplicationDbContext _db;
        public ContactUsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
        #endregion
    }
}