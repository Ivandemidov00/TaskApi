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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task, TaskLookupDto>()
                .ForMember(taskDto => taskDto.ID,
                    opt => opt.MapFrom(task => task.ID))
                .ForMember(taskDto => taskDto.Name,
                    opt => opt.MapFrom(task => task.Name));
        }  
    }
}