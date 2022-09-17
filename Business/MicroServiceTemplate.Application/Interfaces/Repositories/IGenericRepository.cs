using System;
using System.Linq.Expressions;

namespace MicroServiceTemplate.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T,TId> where T : BaseEntity<TId>
    {
        Task<List<T>> GetAllAsync(bool isActive);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> AddAsync(T entity);
        Task<T> GetByIdAsync(TId Id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> DeleteByIdAsync(TId Id);
        Task<bool> UpdateAsync(T entity);
    }
}

