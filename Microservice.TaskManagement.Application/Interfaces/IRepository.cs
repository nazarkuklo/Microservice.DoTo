using Microservice.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Persistence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity<int>, new()
    {
        public Task<TEntity> GetByIdAsync(int Id);
        Task<List<TEntity>> GetAllAsync();
        Task<int> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(int id);
    }
}
