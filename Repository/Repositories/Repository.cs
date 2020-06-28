using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{    
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Interface Methods/ CRUD
        
        public async Task Add(T model)
        {
            await _context.AddAsync(model);

            await _context.SaveChangesAsync();
        }
        
        public async Task<T> Get<Property>(Property property)
        {
            return await _context.FindAsync<T>(property);
        }
        
        public async Task Remove(T model)
        {
            _context.Remove(model);

            await _context.SaveChangesAsync();
        }
        
        public async Task Update(T model)
        {
            _context.Update(model);

            await _context.SaveChangesAsync();
        }           

        #endregion

        #region Protected Members
        
        protected readonly DbContext _context;

        #endregion

        #region Constructors
        
        public Repository(DbContext context)
        {
            
            _context = context;
        }

        #endregion
    }
}
