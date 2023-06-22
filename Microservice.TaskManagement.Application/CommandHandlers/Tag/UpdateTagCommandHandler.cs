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
    public class UpdateTagCommandHandler : ICommandHandler<UpdateTagCommand, UpdateTagCommand>
    {
        private readonly IRepository<TagEntity> _repository;
        private readonly IMapper _mapper;
        public UpdateTagCommandHandler(IRepository<TagEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdateTagCommand> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TagEntity>(request);
            var entityResult = await _repository.UpdateAsync(entity);
            var result = _mapper.Map<UpdateTagCommand>(entityResult);

            return result;
        }
    }
}
