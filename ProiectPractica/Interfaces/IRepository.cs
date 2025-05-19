using System.Linq.Expressions;

namespace ProiectPractica.Interfaces
{
    public interface IRepository<T>
    {
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task SaveAsync();
        void Update(T entity);
        IQueryable<T> GetAllQueryable();
        Task<T> GetByIdAsync(string id);
        Task<T> GetByIdAsync(Guid id);
        Task DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
        IQueryable<T> GetQueryableWithIncludes(params Expression<Func<T, object>>[] includes);


    }
}