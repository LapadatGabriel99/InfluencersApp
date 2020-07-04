using BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAuthorService
    {
        Task<RankingViewModel> GetAuthorsByScore();

        Task<RankingViewModel> GetAuthorsByNumberOfArticles();

        Task<RankingViewModel> GetAuthorsByCommentedArticles();
    }
}
