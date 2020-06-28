using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{    
    public interface IRepository<T> where T : class
    {        
        Task Add(T model);
        
        Task Update(T model);
        
        Task Remove(T model);
       
        Task<T> Get<Property>(Property property);        
    }
}
