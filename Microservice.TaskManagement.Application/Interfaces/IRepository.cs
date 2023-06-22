using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Persistence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity<int>, new()
    {
        public Task<IPaginatedListDto<T>> GetOrderedPaginatedListAsync<T>(
    int currentPage = 1,
    int pageSize = 5,
    bool trackingEnabled = false
);
        public Task<TEntity> GetByIdAsync(int Id);
        Task<List<TEntity>> GetAllAsync();
        Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<ICollection<T>> GetAsync<T>(Expression<Func<T, bool>> expression) where T : class;

Task<TEntity> AddAsync(TEntity entity);
        Task<ICollection<T>> AddRangeAsync<T>(ICollection<T> list) where T : class;
        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> list);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task RemoveRangeAsync(ICollection<TEntity> list);
        Task RemoveRangeAsync<T>(ICollection<T> list) where T : class;
        Task RemoveAsync(int id);
    }
}
