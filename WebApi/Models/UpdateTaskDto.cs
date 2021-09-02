using System;
using Application.Common.Mappings;
using Application.Tasks.Commands.UpdateTask;
using AutoMapper;

namespace WebApi.Models
{
    public class UpdateTaskDto:IMapWith<UpdateTaskCommand>
    {
        
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTaskDto, UpdateTaskCommand>()
                .ForMember(taskCommand => taskCommand.ID,
                    opt => opt.MapFrom(taskDto => taskDto.Id))
                .ForMember(taskCommand => taskCommand.Name,
                    opt => opt.MapFrom(taskDto => taskDto.Name))
                .ForMember(taskCommand => taskCommand.Description,
                    opt => opt.MapFrom(taskDto => taskDto.Description));
        }
    }
}