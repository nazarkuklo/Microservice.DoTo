using AutoMapper;
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
    public class UpdateStatusCommandHandler : ICommandHandler<UpdateStatusCommand, UpdateStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateStatusCommand> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StatusEntity>(request);
            var entityResult = await _unitOfWork.StatusRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<UpdateStatusCommand>(entityResult);

            return result;
        }
    }
}
