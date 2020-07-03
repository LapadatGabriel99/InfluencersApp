using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Data.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IContactService, ContactsService>();
            services.AddScoped<IAuthorService, AuthorService>();

            return services;
        }
    }
}
