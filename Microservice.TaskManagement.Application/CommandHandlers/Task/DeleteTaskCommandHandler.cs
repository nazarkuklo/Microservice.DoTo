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
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Tasks.RemoveAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
