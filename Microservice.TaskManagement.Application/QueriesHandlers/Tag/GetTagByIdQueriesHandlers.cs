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
    public class GetTagByIdQueriesHandlers : IQueryHandler<GetTagById, TagDto>
    {
        private readonly IRepository<TagEntity> _repository;
        private readonly IMapper _mapper;

        public GetTagByIdQueriesHandlers(IRepository<TagEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TagDto> Handle(GetTagById query, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetByIdAsync(query.Id);
            var result = _mapper.Map<TagDto>(tag);
            return result;
        }
    }
}
