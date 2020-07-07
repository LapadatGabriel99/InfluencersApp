using BusinessLogic.DataTransfer;
using BusinessLogic.Enums;
using BusinessLogic.Filters;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
       
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;           
        }

        public async Task<RankingViewModel> GetAuthorsByScore()
        {
            var authors = await _authorRepository.GetAuthorsByScore();

            var rankingData = authors.GetRankingData(RankBy.Score);

            return new RankingViewModel { RankingData = rankingData };
        }

        public async Task<RankingViewModel> GetAuthorsByNumberOfArticles()
        {
            var authors = await _authorRepository.GetAuthorsByNumberOfArticles();
           
            var rankingData = authors.GetRankingData(RankBy.NumberOfArticles);

            return new RankingViewModel { RankingData = rankingData };
        }

        public async Task<RankingViewModel> GetAuthorsByCommentedArticles()
        {
            return new RankingViewModel
            {
                RankingData = new List<RankingDataTransfer>() { new RankingDataTransfer() }
            };
        }
    }
}
