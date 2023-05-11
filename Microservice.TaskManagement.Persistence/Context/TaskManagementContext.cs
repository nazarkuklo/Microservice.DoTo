using Microservice.TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Persistence.Context
{
    public class TaskManagementContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<StatusEntity> Statuses { get; set; }

        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskEntity>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TagEntity>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<StatusEntity>().Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
