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
    public class TagRepository : Repository<Tag>, ITagRepository
    {       
        public TagRepository(InfluencersContext context) : base(context)
        {

        }
      
        private InfluencersContext Context { get => _context as InfluencersContext; }   
       
        public async Task<ICollection<Tag>> GetAll()
        {
            return await Context.Tag.ToListAsync();
        }
        
        public async Task AddRange(ICollection<Tag> tags)
        {
            await Context.Tag.AddRangeAsync(tags);

            await Context.SaveChangesAsync();
        }
        
        public async Task RemoveRange(ICollection<Tag> tags)
        {
            Context.Tag.RemoveRange(tags);

            await Context.SaveChangesAsync();
        }  
    }
}
