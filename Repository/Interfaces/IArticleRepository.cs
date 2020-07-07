using DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<ICollection<Article>> GetAll();

        Task<Article> GetCompleteArticle(int id);

        Task AddRange(ICollection<Article> articles);

        Task RemoveRange(ICollection<Article> articles);

        Task AddArticleWithAuthorAndTags(Article article, Author author, Tag tag);

        Task<IEnumerable<Article>> GetArticlesWithAuthors();

        Task UpdateArticleWithTags(Article article, Tag tag);

        Task<bool> UpdateArticleAuthorScore(int id, int score);

        Task<bool> AddCommentToArticle(int id, string nickname, string content);
    }
}
