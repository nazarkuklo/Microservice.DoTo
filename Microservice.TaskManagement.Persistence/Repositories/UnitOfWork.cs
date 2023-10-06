using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Context;
using Microservice.TaskManagement.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Persistence.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;
        public ITaskRepository TaskRepository { get; }

        public ITagRepository TagRepository { get; }

        public IStatusRepository StatusRepository { get; }

        public UnitOfWork(TContext context, ITaskRepository Tasks, ITagRepository Tags, IStatusRepository Statuses)
        {
            _context = context;
            this.TaskRepository = Tasks;
            this.TagRepository = Tags;
            this.StatusRepository = Statuses;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
