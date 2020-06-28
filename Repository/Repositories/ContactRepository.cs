using DataAccess.Context;
using DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public InfluencersContext Context { get => _context as InfluencersContext; }

        public ContactRepository(InfluencersContext context) : base(context)
        {
            
        }

        public async Task<ICollection<Contact>> GetAll()
        {
            return await Context.Contact.ToListAsync();
        }
    }
}
