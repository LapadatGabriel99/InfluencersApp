using DataAccess.Context;
using DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                .Include(x => x.Comments)
                .Where(x => x.Id == id)
                .Select(a => new { a, ArticleTags = Context.ArticleTags.Include(at => at.Tag).Where(at => at.ArticleId == id) })
                .Select(b => new Article
                {
                    Title = b.a.Title,
                    Content = b.a.Content,
                    AuthorNickname = b.a.AuthorNickname,
                    Id = b.a.Id,
                    AuthorId = b.a.AuthorId,
                    CreationDate = b.a.CreationDate,
                    Author = b.a.Author,
                    ArticleTags = b.ArticleTags,
                    Comments = b.a.Comments.OrderByDescending(c => c.PublishDate).ToList()
                })
                .FirstOrDefaultAsync();           
        }

        public async Task AddArticleWithAuthorAndTags(Article article, Author author, Tag tag)
        {
            var articleTags = new ArticleTags();

            var existingAuthor = await Context.Author
                .Include(a => a.Article)
                .Where(a => a.Email == author.Email)
                .FirstOrDefaultAsync();

            if (existingAuthor == null)
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
                article.Author = existingAuthor;
                existingAuthor.Article.Add(article);

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
                .Select(a => new { a.Id, a.Title, a.Content, a.CreationDate, a.AuthorNickname })
                .Select(b => new Article
                {
                    Id = b.Id,
                    Title = b.Title,
                    Content = b.Content,
                    CreationDate = b.CreationDate,
                    AuthorNickname = b.AuthorNickname                    
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

        public async Task<bool> UpdateArticleAuthorScore(int id, int score)
        {
            var article = await Context.Article.Include(a => a.Author).Where(a => a.Id == id).FirstOrDefaultAsync();

            article.Author.Votes += score;

            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddCommentToArticle(int id, string nickname, string content)
        {
            var article = await Context.Article.Include(a => a.Comments).Where(a => a.Id == id).FirstOrDefaultAsync();

            article.Comments.Add(new Comment
            {
                Content = content,
                Nickname = nickname,
                PublishDate = DateTime.Now,
                Article = article
            });

            return await Context.SaveChangesAsync() > 0;
        }
    }
}
