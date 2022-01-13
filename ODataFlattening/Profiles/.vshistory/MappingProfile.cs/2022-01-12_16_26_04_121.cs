using AutoMapper;
using FCSBackendAuthentication.Models;
using Microsoft.AspNetCore.Identity;
using ToolRoom.Data.Models;
using ToolRoom.Shared.DTOs;
using ToolRoom.Shared.Enums;

namespace ToolRoom.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Type locationType = typeof(LocationType);
            Type toolLifeType = typeof(ToolLifeType);
            Type operationType = typeof(OperationType);
            Type taskStatusType = typeof(Shared.Enums.TaskStatus);
            Type taskTypeType = typeof(TaskType);

            CreateMap<Component, ComponentDTO>().ReverseMap();
            CreateMap<ComponentFamily, ComponentFamilyDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ForMember(location => location.Type, opt => opt.MapFrom(location => Enum.Parse(locationType, location.Type))).ReverseMap();
            CreateMap<Matrix, MatrixDTO>().ReverseMap();
            CreateMap<Operation, OperationDTO>().ForMember(operation => operation.Type, opt => opt.MapFrom(operation => Enum.Parse(operationType, operation.Type)));
            CreateMap<Data.Models.Task, TaskDTO>().ForMember(task => task.Status, opt => opt.MapFrom(task => Enum.Parse(taskStatusType, task.Status)))
                .ForMember(task => task.Type, opt => opt.MapFrom(task => Enum.Parse(taskTypeType, task.Type)))
                .ReverseMap();
            CreateMap<TaskExecution, TaskExecutionDTO>().ForMember(taskExecution => taskExecution.Status, opt => opt.MapFrom(taskExecution => Enum.Parse(taskStatusType, taskExecution.Status))).ReverseMap();
            CreateMap<Tool, ToolDTO>().ForMember(tool => tool.Components, opt => opt.MapFrom(tool => tool.ComponentPerTools.OrderBy(cpt => cpt.Index).Select(cpt => cpt.Component)))
                .ForMember(tool => tool.LifeType, opt => opt.MapFrom(tool => Enum.Parse(toolLifeType, tool.LifeType)))
                .ForMember(tool => tool.Matrix, opt => opt.MapFrom(tool => tool.Matrices.OrderBy(matrix => matrix.Id).LastOrDefault()))
                .ReverseMap();

            CreateMap<IdentityUser, User>()
                .ForMember(u => u.IsLocked, opt => opt.MapFrom(u => u.LockoutEnd > DateTime.Now))
                .ReverseMap();
            CreateMap<IdentityRole, Role>().ReverseMap();
        }
    }
}
