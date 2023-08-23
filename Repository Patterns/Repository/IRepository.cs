using Repository_Patterns.Models;

namespace Repository_Patterns.Repository
{
    public interface IRepository <T> where T : class
    {
        Task<List<T>> GetAllAsync();
        T GetProductById(int prodId);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        
    }
}
