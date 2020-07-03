using BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<RankingViewModel>> GetAuthorsByScore();

        Task<IEnumerable<RankingViewModel>> GetAuthorsByVotes();
    }
}
