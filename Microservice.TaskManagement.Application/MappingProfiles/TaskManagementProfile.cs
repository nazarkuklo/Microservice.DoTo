using AutoMapper;
using Microservice.TaskManagement.Application.Commands.Status;
using Microservice.TaskManagement.Application.Commands.Tag;
using Microservice.TaskManagement.Application.Commands.Task;
using Microservice.TaskManagement.Application.Common.DTO.Responses;
using Microservice.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.MappingProfiles
{
    public class TaskManagementProfile : Profile
    {
        public TaskManagementProfile()
        {
            CreateMap<TagEntity, TagDto>().ReverseMap();
            CreateMap<TaskEntity, TaskDto>().ReverseMap();
            CreateMap<StatusEntity, StatusDto>().ReverseMap();

            CreateMap<TagEntity, CreateTagCommand>().ReverseMap();
            CreateMap<TaskEntity, CreateTaskCommand>().ReverseMap();
            CreateMap<StatusEntity, CreateStatusCommand>().ReverseMap();

            CreateMap<TagEntity, UpdateTagCommand>().ReverseMap();
            CreateMap<TaskEntity, UpdateTaskCommand>().ReverseMap();
            CreateMap<StatusEntity, UpdateStatusCommand>().ReverseMap();

            CreateMap<TagEntity, TaskTagDto>().ReverseMap();
            CreateMap<StatusEntity, TaskStatusDto>().ReverseMap();
        }
    }
}
