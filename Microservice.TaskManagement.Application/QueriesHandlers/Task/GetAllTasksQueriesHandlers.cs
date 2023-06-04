using AutoMapper;
using Microservice.TaskManagement.Application.Common.DTO.Responses;
using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Application.Queries.Tag;
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
    public class GetAllTasksQueriesHandlers : IQueryHandler<GetAllTasks, IPaginatedResponseDto<ICollection<TaskDto>>>
    {
        private readonly IRepository<TaskEntity> _repository;
        private readonly IMapper _mapper;
        public GetAllTasksQueriesHandlers(IRepository<TaskEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IPaginatedResponseDto<ICollection<TaskDto>>> Handle(GetAllTasks query, CancellationToken cancellationToken)
        {
            var reports = await _repository.GetOrderedPaginatedListAsync<TaskDto>(
                query.Page,
                query.PageSize
                );

            return new PaginatedResponseDto<ICollection<TaskDto>>(reports.Result, reports.TotalItems);
        }
    }
}
