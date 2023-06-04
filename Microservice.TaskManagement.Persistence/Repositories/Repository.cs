using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        protected readonly IMapper Mapper;

        public Repository(TContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Mapper = mapper;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<ICollection<T>> GetAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await _context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            return entity;
        }

        public async Task<ICollection<T>> AddRangeAsync<T>(ICollection<T> list) where T : class
        {
            await _context.Set<T>().AddRangeAsync(list);

            return list;
        }

        public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> list)
        {
            await _context.Set<TEntity>().AddRangeAsync(list);

            return list;
        }

        public  Task<TEntity> UpdateAsync(TEntity entity)
        {
             _context.Set<TEntity>().Update(entity);

            return Task.FromResult(entity);
        }

        public Task RemoveAsync(int id)
        {
           var entities = _context.Set<TEntity>();
            entities.Remove(entities.FirstOrDefault(x => x.Id == id));
            return Task.CompletedTask;
        }

        public Task RemoveRangeAsync<T>(ICollection<T> list) where T : class
        {
            var entities = _context.Set<T>();
            entities.RemoveRange(list);
            return Task.CompletedTask;
        }

        public Task RemoveRangeAsync(ICollection<TEntity> list)
        {
            var entities = _context.Set<TEntity>();
            entities.RemoveRange(list);
            return Task.CompletedTask;
        }

        public async Task<IPaginatedListDto<T>> GetOrderedPaginatedListAsync<T>(int currentPage = 1, int pageSize = 5, bool trackingEnabled = false)
        {
            IQueryable<TEntity> entities = _context.Set<TEntity>();
            if (!trackingEnabled)
            {
                entities = entities.AsNoTracking();
            }

            var models = entities.ProjectTo<T>(Mapper.ConfigurationProvider);
            return await models.ToPaginatedListAsync(currentPage, pageSize);
        }
    }
}
