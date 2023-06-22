using MediatR;
using Microservice.TaskManagement.Application.Commands.Task;
using Microservice.TaskManagement.Application.Interfaces;
using Microservice.TaskManagement.Domain.Entities;
using Microservice.TaskManagement.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.CommandHandlers.Task
{
    class DeleteTaskCommandHandler : ICommandHandler<DeleteTaskCommand>
    {
        private readonly IRepository<TaskEntity> _repository;
        public DeleteTaskCommandHandler(IRepository<TaskEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            return Unit.Value;
        }
    }
}
