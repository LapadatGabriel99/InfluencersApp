using BusinessLogic.DataTransfer;
using BusinessLogic.Filters;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Data.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ArticleService : IArticleService
    {
        private IArticleRepository _articleRepository;
        private IAuthorRepository _authorRepository;
        private ITagRepository _tagRepository;

        public ArticleService(IArticleRepository articleRepository, IAuthorRepository authorRepository, ITagRepository tagRepository)
        {
            _articleRepository = articleRepository;
            _authorRepository = authorRepository;
            _tagRepository = tagRepository;
        }             

        public async Task<IEnumerable<IndexViewModel>> GetListOfIndexViewModels()
        {
            var articles = await _articleRepository.GetArticlesWithAuthors();            

            var authorArticles = articles.GetAuthorArticles();

            ICollection<IndexViewModel> indexViewModelList = new List<IndexViewModel>();

            authorArticles.ToList().ForEach(a =>
            {                                
                indexViewModelList.Add(new IndexViewModel { DisplayData = a});
            });                      

            return indexViewModelList;
        }

        public async Task<ArticleDetailsViewModel> GetArticleDetailsViewModel(int id)
        {            
            var article = await _articleRepository.GetCompleteArticle(id);                        

            return new ArticleDetailsViewModel { ArticleDetails = article.GetArticleDetails()};
        }

        public async Task AddArticle(CreateArticleDataTranser article)
        {
            await _articleRepository.AddArticleWithAuthorAndTags
                (
                    new Article
                    {
                        Title = article.Title,
                        Content = article.Content,
                        CreationDate = DateTime.UtcNow,                        
                    },
                    new Author
                    {
                        Nickname = article.AuthorNickname,
                        Email = article.AuthorEmail
                    },
                    new Tag
                    {
                        Name = article.Tags
                    }
                );            
        }

        public async Task UpdateArticle(ArticleDetailsDataTransfer article)
        {
            await _articleRepository.UpdateArticleWithTags
                (
                    new Article
                    {
                        Id = article.ArticleId,
                        Title = article.Title,
                        Content = article.Content,                        
                    },
                    new Tag
                    {
                        Name = article.Tag
                    }
                );
        }
    }
}
