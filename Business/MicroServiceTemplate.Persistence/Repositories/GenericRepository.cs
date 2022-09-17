using System;
using System.Linq.Expressions;
using MicroServiceTemplate.Domain.Common;
using MicroServiceTemplate.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceTemplate.Persistence.Repositories
{
    public class GenericRepository<T,TId> : IGenericRepository<T,TId> where T : BaseEntity<TId> where TId: IEquatable<TId>
    {
        public async Task<bool> AddAsync(T entity)
        {
            using (MicroServiceContext context = new MicroServiceContext())
            {
                await context.AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> DeleteByIdAsync(TId Id)
        {
            using (MicroServiceContext context = new MicroServiceContext())
            {
                var entity = context.Set<T>().FirstOrDefault(a => a.Id.Equals(Id));
                if (entity == null)
                    return false;
                context.Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public Task<List<T>> GetAllAsync(bool isActive)
        {
            using (MicroServiceContext context = new MicroServiceContext())
            {
                var result = context.Set<T>().Where(a => a.IsActive == isActive).ToList();
                return Task.FromResult(result);
            }
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            using (MicroServiceContext context = new MicroServiceContext())
            {
                return Task.FromResult(filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList());
            }
        }

        public Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter = null)
        {
            using (MicroServiceContext context = new MicroServiceContext())
            {
                return Task.FromResult(context.Set<T>().SingleOrDefault(filter))!;
            }
        }

        public Task<T> GetByIdAsync(TId Id)
        {
            using (MicroServiceContext context = new MicroServiceContext())
            {
                return Task.FromResult(context.Set<T>().SingleOrDefault(a => a.Id.Equals(Id)))!;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            using (MicroServiceContext context = new MicroServiceContext())
            {
                context.Entry<T>(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}


