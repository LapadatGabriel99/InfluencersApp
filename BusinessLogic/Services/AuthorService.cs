using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        private readonly IArticleRepository _articleRepository;

        public AuthorService(IAuthorRepository authorRepository, IArticleRepository articleRepository)
        {
            _authorRepository = authorRepository;

            _articleRepository = articleRepository;
        }

        public async Task<IEnumerable<RankingViewModel>> GetAuthorsByScore()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<RankingViewModel>> GetAuthorsByVotes()
        {
            throw new System.NotImplementedException();
        }
    }
}
