using DataAccess.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IContactRepository : IRepository<Contact>
    {
        public Task<ICollection<Contact>> GetAll();
    }
}
