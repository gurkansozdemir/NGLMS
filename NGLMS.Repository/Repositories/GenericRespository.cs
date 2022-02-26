using Microsoft.EntityFrameworkCore;
using NGLMS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NGLMS.Repository.Repositories
{
    public class GenericRespository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;

        public GenericRespository(AppDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbset.Where(expression);
        }
        public IQueryable<T> GetAll()
        {
            return _dbset.AsNoTracking().AsQueryable();
        }
        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }
        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
        }
        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbset.UpdateRange(entities);
        }
    }
}
