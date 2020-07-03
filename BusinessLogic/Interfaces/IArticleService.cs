using BusinessLogic.DataTransfer;
using BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IArticleService
    {         
        Task<IEnumerable<IndexViewModel>> GetListOfIndexViewModels();

        Task<ArticleDetailsViewModel> GetArticleDetailsViewModel(int id);

        Task AddArticle(CreateArticleDataTranser article);

        Task UpdateArticle(ArticleDetailsDataTransfer article);

        Task<bool> UpdateScore(VoteDataTransfer voteData);
    }
}
