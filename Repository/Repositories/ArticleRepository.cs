using DataAccess.Context;
using DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {        
        public ArticleRepository(InfluencersContext context) : base(context)
        {

        }
     
        private InfluencersContext Context
        {
            get => _context as InfluencersContext;
        }
       
        public async Task<ICollection<Article>> GetAll()
        {
            return await Context.Article.ToListAsync();
        }
       
        public async Task AddRange(ICollection<Article> articles)
        {
            await Context.Article.AddRangeAsync(articles);

            await Context.SaveChangesAsync();
        }
        
        public async Task RemoveRange(ICollection<Article> articles)
        {
            Context.Article.RemoveRange(articles);

            await Context.SaveChangesAsync();
        }

        public async Task<Article> GetCompleteArticle(int id)
        {
            return await Context.Article
                .Include(x => x.Author)
                .Include(x => x.ArticleTags)                
                .Where(x => x.Id == id)
                .Select(a => new { a, ArticleTags = Context.ArticleTags.Include(at => at.Tag).Where(at => at.ArticleId == id) })
                .Select(b => new Article
                {
                    Title = b.a.Title,
                    Content = b.a.Content,
                    Id = b.a.Id,
                    AuthorId = b.a.AuthorId,
                    CreationDate = b.a.CreationDate,
                    Author = b.a.Author,
                    ArticleTags = b.ArticleTags
                })
                .FirstOrDefaultAsync();           
        }

        public async Task AddArticleWithAuthorAndTags(Article article, Author author, Tag tag)
        {
            var articleTags = new ArticleTags();

            var a = await Context.Author.Where(a => a.Email == author.Email).FirstOrDefaultAsync();

            if (a == null)
            {
                article.Author = author;
                author.Article.Add(article);

                articleTags.Article = article;
                articleTags.Tag = tag;

                await Context.ArticleTags.AddAsync(articleTags);

                await Context.Article.AddAsync(article);
                
                await Context.Author.AddAsync(author);

                await Context.SaveChangesAsync();

                return;
            }
            else
            {
                article.Author = author;
                author.Article.Add(article);

                articleTags.Article = article;
                articleTags.Tag = tag;

                await Context.ArticleTags.AddAsync(articleTags);

                await Context.Article.AddAsync(article);

                await Context.SaveChangesAsync();

                return;
            }            
        }

        public async Task<IEnumerable<Article>> GetArticlesWithAuthors()
        {
            return await Context.Article
                .Include(x => x.Author)
                .Select(a => new { a.Author, a.Id, a.Title, a.Content, a.CreationDate })
                .Select(b => new Article
                {
                    Id = b.Id,
                    Title = b.Title,
                    Content = b.Content,
                    CreationDate = b.CreationDate,
                    Author = b.Author
                })
                .OrderByDescending(a => a.CreationDate)
                .ToListAsync();
        }

        public async Task UpdateArticleWithTags(Article article, Tag tag)
        {
            var articleTags = await Context.ArticleTags.Include(at => at.Tag).Where(at => at.ArticleId == article.Id).FirstOrDefaultAsync();            

            articleTags.Tag.Name = tag.Name;

            var currentArticle = await Context.Article.Where(a => a.Id == article.Id).FirstOrDefaultAsync();

            currentArticle.Title = article.Title;
            currentArticle.Content = article.Content;

            await Context.SaveChangesAsync();
        }
    }
}
