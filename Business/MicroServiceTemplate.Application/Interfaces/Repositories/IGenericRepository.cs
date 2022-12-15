using System;
using System.Linq.Expressions;

namespace MicroServiceTemplate.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(bool isActive);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> AddAsync(T entity);
        Task<T> GetByIdAsync(Guid Id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> DeleteByIdAsync(Guid Id);
        Task<bool> UpdateAsync(T entity);
    }
}

