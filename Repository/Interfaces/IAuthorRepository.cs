using DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{   
    public interface IAuthorRepository : IRepository<Author>
    {        
        Task<ICollection<Author>> GetAll();
       
        Task AddRange(ICollection<Author> articles);
        
        Task RemoveRange(ICollection<Author> articles);

        Task<IEnumerable<Author>> GetAuthorsByScore();

        Task<IEnumerable<Author>> GetAuthorsByNumberOfArticles();

        Task<IEnumerable<Author>> GetAuthorsByNumberOfCommentedArticles();
    }
}
