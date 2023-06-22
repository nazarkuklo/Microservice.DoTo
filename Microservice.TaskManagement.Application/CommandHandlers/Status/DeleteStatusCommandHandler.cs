using MediatR;
using Microservice.TaskManagement.Application.Commands.Status;
using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.CommandHandlers.Status
{
    public class DeleteStatusCommandHandler : ICommandHandler<DeleteStatusCommand>
    {
        private readonly IRepository<StatusEntity> _repository;
        public DeleteStatusCommandHandler(IRepository<StatusEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            return Unit.Value;
        }
    }
}
