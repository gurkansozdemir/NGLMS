using System.Linq.Expressions;

namespace NGLMS.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        // Asenkron metodlar
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        // Memory'de sadece status'ü değiştirdiği için uzun süren bir işlem olmadığından delte ve update işlemlerinin asenkron metodu yok EF Core'da.
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }
}
