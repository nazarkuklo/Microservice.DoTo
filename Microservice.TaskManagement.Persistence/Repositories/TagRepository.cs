using AutoMapper;
using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Persistence.Repositories
{
    public class TagRepository : Repository<TagEntity, TaskManagementContext>, ITagRepository
    {
        public TagRepository(TaskManagementContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
