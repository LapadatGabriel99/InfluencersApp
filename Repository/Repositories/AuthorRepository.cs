using DataAccess.Context;
using DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{    
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        #region Constructors
        
        public AuthorRepository(InfluencersContext context) : base(context)
        {

        }

        #endregion

        #region Private Properties
        
        private InfluencersContext Context { get => _context as InfluencersContext; }

        #endregion

        #region Interface Implementation
        
        public async Task<ICollection<Author>> GetAll()
        {
            return await Context.Author.ToListAsync();
        }
        
        public async Task AddRange(ICollection<Author> authors)
        {
            await Context.Author.AddRangeAsync(authors);

            await Context.SaveChangesAsync();
        }
        
        public async Task RemoveRange(ICollection<Author> authors)
        {
            Context.Author.RemoveRange(authors);

            await Context.SaveChangesAsync();
        }

        #endregion
    }
}
