using MediatR;
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
    public class DeleteTagCommandHandler : ICommandHandler<DeleteTagCommand>
    {
        private readonly IRepository<TagEntity> _repository;
        public DeleteTagCommandHandler(IRepository<TagEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
           await _repository.RemoveAsync(request.Id);
            return Unit.Value;
        }
    }
}
