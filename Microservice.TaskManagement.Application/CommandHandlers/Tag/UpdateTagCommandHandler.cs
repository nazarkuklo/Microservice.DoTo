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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateTagCommand> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TagEntity>(request);
            var entityResult = await _unitOfWork.TagRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<UpdateTagCommand>(entityResult);

            return result;
        }
    }
}
