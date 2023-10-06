﻿using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ITaskRepository TaskRepository { get; }
        ITagRepository TagRepository { get; }
        IStatusRepository StatusRepository { get; }

        Task SaveChangesAsync();
    }
}
