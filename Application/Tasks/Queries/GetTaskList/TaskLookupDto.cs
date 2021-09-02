using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.Tasks.Queries.GetTaskList
{
    public class TaskLookupDto:IMapWith<Task>
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        
        public String Description { get; set; }
        public String Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task, TaskLookupDto>()
                .ForMember(taskDto => taskDto.ID,
                    opt => opt.MapFrom(task => task.ID))
                .ForMember(taskDto => taskDto.Name,
                    opt => opt.MapFrom(task => task.Name))
                .ForMember(taskDto => taskDto.Description,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(taskDto => taskDto.Status,
                    opt => opt.MapFrom(task => task.Status.Status_name));
        }  
    }
}