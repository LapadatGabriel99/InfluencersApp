using DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{    
    public interface ITagRepository : IRepository<Tag>
    {        
        Task<ICollection<Tag>> GetAll();
        
        Task AddRange(ICollection<Tag> articles);
        
        Task RemoveRange(ICollection<Tag> articles);
    }
}
