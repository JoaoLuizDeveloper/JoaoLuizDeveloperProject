using JoaoLuizDeveloper.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JoaoLuizDeveloper.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<NewsLetter> NewsLetter { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Resume> Resume { get; set; }
    }
}