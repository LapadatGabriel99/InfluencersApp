﻿using DataAccess.Data.Models;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DataTransfer;

namespace BusinessLogic.Filters
{
    public static class ArticleFilters
    {
        public static IEnumerable<IndexDisplayDataTransfer> GetAuthorArticles(this IEnumerable<Article> articles)
        {            
            ICollection<IndexDisplayDataTransfer> displayDataList = new List<IndexDisplayDataTransfer>();

            articles.ToList().ForEach(a =>
            {
                displayDataList.Add(new IndexDisplayDataTransfer 
                {
                    Id = a.Id,
                    Title = a.Title, 
                    ShortContent = a.Content, 
                    AuthorNickname = a.Author.Nickname, 
                }
                );
            });

            return displayDataList;
        } 

        public static IEnumerable<Tag> GetTagsOfAnArticle(this Article article, ICollection<Tag> tags)
        {
            var tagsOfAnArticle = from articleTag in article.ArticleTags
                                  join tag in tags on articleTag.TagId equals tag.Id
                                  select new { tag.Name, tag.Id };

            ICollection<Tag> tagList = new List<Tag>();

            tagsOfAnArticle.ToList().ForEach(a =>
            {
                tagList.Add(new Tag { Name = a.Name, Id = a.Id });
            });

            return tagList;
        }

        public static ArticleDetailsDataTransfer GetArticleDetails(this Article article)
        {
            return new ArticleDetailsDataTransfer
            {
                ArticleId = article.Id,
                AuthorEmail = article.Author.Email,
                AuthorNickname = article.Author.Nickname,
                Content = article.Content,
                Title = article.Title,
                CreationDate = article.CreationDate,
                ArticleTags = article.ArticleTags.Select(at => at.Tag.Name),
            };
        }
    }
}