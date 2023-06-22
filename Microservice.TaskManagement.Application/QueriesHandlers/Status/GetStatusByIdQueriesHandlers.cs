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
    class GetStatusByIdQueriesHandlers : IQueryHandler<GetStatusById, StatusDto>
    {
        private readonly IRepository<StatusEntity> _repository;
        private readonly IMapper _mapper;

        public GetStatusByIdQueriesHandlers(IRepository<StatusEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StatusDto> Handle(GetStatusById query, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetByIdAsync(query.Id);
            var result = _mapper.Map<StatusDto>(tag);
            return result;
        }
    }
}
