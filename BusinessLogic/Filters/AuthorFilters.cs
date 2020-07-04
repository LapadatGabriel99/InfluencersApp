using BusinessLogic.DataTransfer;
using BusinessLogic.Enums;
using DataAccess.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Filters
{
    public static class AuthorFilters
    {
        public static IEnumerable<RankingDataTransfer> GetRankingData(this IEnumerable<Author> authors, RankBy by)
        {
            ICollection<RankingDataTransfer> rankingData = new List<RankingDataTransfer>();

            if(by == RankBy.Score)
            {
                authors.ToList().ForEach(a =>
                {
                    rankingData.Add(new RankingDataTransfer
                    {
                        AuthorNickname = a.Nickname,
                        AuthorEmail = a.Email,
                        AuthorScore = a.Votes
                    });
                });
            }
            else if(by == RankBy.NumberOfArticles)
            {
                authors.ToList().ForEach(a =>
                {
                    rankingData.Add(new RankingDataTransfer
                    {
                        AuthorNickname = a.Nickname,
                        AuthorEmail = a.Email,
                        AuthorScore = a.Article.Count
                    });
                });
            }            

            return rankingData;
        }
    }
}
