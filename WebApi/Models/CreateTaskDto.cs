using System;
using Application.Common.Mappings;
using Application.Tasks.Commands.CreateTask;
using AutoMapper;
using Domain;

namespace WebApi.Models
{
    public class CreateTaskDto : IMapWith<CreateTaskCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Int32 Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTaskDto, CreateTaskCommand>()
                .ForMember(taskCommand => taskCommand.Name,
                    opt => opt.MapFrom(taskDto => taskDto.Name))
                .ForMember(taskCommand => taskCommand.Description,
                    opt => opt.MapFrom(taskDto => taskDto.Description))
                .ForMember(taskCommand => taskCommand.Status,
                    opt => opt.MapFrom(taskDto => taskDto.Status));
        }
    }
}