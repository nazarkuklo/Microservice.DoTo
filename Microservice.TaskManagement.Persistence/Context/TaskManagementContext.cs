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
        public DbSet<TagEntityTaskEntity> TagTasks { get; set; }

        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TagEntity>().Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<StatusEntity>().Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<TaskEntity>().Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<TaskEntity>()
    .HasMany(e => e.Tags)
    .WithMany(e => e.Tasks)
    .UsingEntity<TagEntityTaskEntity>(
                l => l.HasOne(e => e.Tag).WithMany(e => e.TagEntityTaskEntities),
                r => r.HasOne(e => e.Task).WithMany(e => e.TagEntityTaskEntities)
                );
            //modelBuilder.Entity<StatusEntity>().HasMany(e => e.Tasks).WithOne(e => e.Status).HasForeignKey(e => e.StatusId).IsRequired(false);
        }
    }
}
