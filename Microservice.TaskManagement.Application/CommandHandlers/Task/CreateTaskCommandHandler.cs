using AutoMapper;
using Microservice.TaskManagement.Application.Commands.Task;
using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.CommandHandlers.Task
{
    public class CreateTaskCommandHandler : ICommandHandler<CreateTaskCommand, CreateTaskCommand>
    {
        private readonly IRepository<TaskEntity> _repository;
        private readonly IMapper _mapper;
        public CreateTaskCommandHandler(IRepository<TaskEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateTaskCommand> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TaskEntity>(request);
            var entityResult = await _repository.AddAsync(entity);
            if (request.Tags.Count > 0)
            {
                List<TagEntityTaskEntity> list = new List<TagEntityTaskEntity>();
                foreach (var tag in request.Tags)
                {
                    list.Add(new TagEntityTaskEntity() { TagId = tag.Value, TaskId = entityResult.Id });
                }
                await _repository.AddRangeAsync(list);
            }


            var result = _mapper.Map<CreateTaskCommand>(entityResult);
            return result;
        }
    }
}
