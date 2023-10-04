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
        private readonly IUnitOfWork _unitOfWork;
        public DeleteStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Statuses.RemoveAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
