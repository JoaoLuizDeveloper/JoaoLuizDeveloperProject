using JoaoLuizDeveloper.Application.Application;
using JoaoLuizDeveloper.Domain.Interfaces;
using JoaoLuizDeveloper.Infrastructure.Repository;

namespace JoaoLuizDeveloper.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            #region Application
            services.AddScoped<IAboutUsApplication, AboutUsApplication>();
            services.AddScoped<IContactUsApplication, ContactUsApplication>();
            services.AddScoped<IResumeApplication, ResumeApplication>();
            services.AddScoped<INewsLetterApplication, NewsLetterApplication>();
            #endregion
            
            #region Repository
            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IResumeRepository, ResumeRepository>();
            services.AddScoped<INewsLetterRepository, NewLetterRepository>();
            #endregion

            return services;
        }
    }
}