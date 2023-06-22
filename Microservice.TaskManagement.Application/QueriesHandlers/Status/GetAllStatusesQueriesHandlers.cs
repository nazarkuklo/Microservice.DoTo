using AutoMapper;
using Microservice.TaskManagement.Application.Common.DTO.Responses;
using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Application.Queries.Status;
using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.QueriesHandlers.Status
{
    public class GetAllStatusesQueriesHandlers : IQueryHandler<GetAllStatuses, IPaginatedResponseDto<ICollection<StatusDto>>>
    {
        private readonly IRepository<StatusEntity> _repository;
        private readonly IMapper _mapper;
        public GetAllStatusesQueriesHandlers(IRepository<StatusEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IPaginatedResponseDto<ICollection<StatusDto>>> Handle(GetAllStatuses query, CancellationToken cancellationToken)
        {
            var reports = await _repository.GetOrderedPaginatedListAsync<StatusDto>(
                query.Page,
                query.PageSize
                );

            return new PaginatedResponseDto<ICollection<StatusDto>>(reports.Result, reports.TotalItems);
        }
    }
}
