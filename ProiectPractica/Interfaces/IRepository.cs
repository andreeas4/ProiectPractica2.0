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
    }
}
