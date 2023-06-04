using AutoMapper;
using Microservice.TaskManagement.Application.Common.DTO.Responses;
using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Application.Queries.Task;
using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.QueriesHandlers.Task
{
    public class GetTaskByIdQueriesHandlers : IQueryHandler<GetTaskById, TaskDto>
    {
        private readonly IRepository<TaskEntity> _repository;
        private readonly IMapper _mapper;

        public GetTaskByIdQueriesHandlers(IRepository<TaskEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(GetTaskById query, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetByIdAsync(query.Id);
            var result = _mapper.Map<TaskDto>(tag);
            return result;
        }
    }
}
