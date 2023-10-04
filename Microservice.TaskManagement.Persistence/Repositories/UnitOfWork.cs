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
        public ITaskRepository Tasks { get; }

        public ITagRepository Tags { get; }

        public IStatusRepository Statuses { get; }

        public UnitOfWork(TContext context, ITaskRepository Tasks, ITagRepository Tags, IStatusRepository Statuses)
        {
            _context = context;
            this.Tasks = Tasks;
            this.Tags = Tags;
            this.Statuses = Statuses;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
