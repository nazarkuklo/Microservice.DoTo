using AutoMapper;
using Microservice.TaskManagement.Application.Common.DTO.Responses;
using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Application.Queries.Tag;
using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.QueriesHandlers.Tag
{
    public class GetAllTagsQueriesHandlers : IQueryHandler<GetAllTags, IPaginatedResponseDto<ICollection<TagDto>>>
    {
        private readonly IRepository<TagEntity> _repository;
        private readonly IMapper _mapper;
        public GetAllTagsQueriesHandlers(IRepository<TagEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IPaginatedResponseDto<ICollection<TagDto>>> Handle(GetAllTags query, CancellationToken cancellationToken)
        {
            var reports = await _repository.GetOrderedPaginatedListAsync<TagDto>(
                query.Page,
                query.PageSize
                );

            return new PaginatedResponseDto<ICollection<TagDto>>(reports.Result, reports.TotalItems);
        }
    }
}
