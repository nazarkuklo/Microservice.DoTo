using AutoMapper;
using Microservice.TaskManagement.Application.Commands.Tag;
using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.CommandHandlers.Tag
{
    public class CreateTagCommandHandler : ICommandHandler<CreateTagCommand, CreateTagCommand>
    {
        private readonly IRepository<TagEntity> _repository;
        private readonly IMapper _mapper;
        public CreateTagCommandHandler(IRepository<TagEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateTagCommand> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TagEntity>(request);
            var entityResult = await _repository.AddAsync(entity);
            var result = _mapper.Map<CreateTagCommand>(entityResult);
            return result;
        }
    }
}
