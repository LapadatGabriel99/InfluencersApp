using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories;

namespace Repository.Extensions
{    
    public static class DataStoreExtensions
    {        
        public static IServiceCollection AddInfluencersStores(this IServiceCollection services)
        {            
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            
            return services;
        }
    }
}
