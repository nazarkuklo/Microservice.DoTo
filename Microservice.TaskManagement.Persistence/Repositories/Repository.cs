using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Persistence.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity<int>, new()
        where TContext : DbContext
    {
        private readonly TContext _context;
        public TContext Context => _context;

        public Repository(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            return entity;
        }

        public Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            return Task.CompletedTask;
        }

        public Task RemoveAsync(int id)
        {
           var entities = _context.Set<TEntity>();
            entities.Remove(entities.FirstOrDefault(x => x.Id == id));
            return Task.CompletedTask;
        }


    }
}
