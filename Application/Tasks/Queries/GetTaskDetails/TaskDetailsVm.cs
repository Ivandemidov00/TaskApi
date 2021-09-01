using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.Tasks.Queries.GetTaskDetails
{
    public class TaskDetailsVm:IMapWith<Task>
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Status Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task, TaskDetailsVm>()
                .ForMember(taskVM => taskVM.Id,
                    opt => opt.MapFrom(task => task.ID))
                .ForMember(taskVm => taskVm.Name,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(taskVm => taskVm.Description,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(taskVM => taskVM.Status,
                    opt => opt.MapFrom(task => task.Status));
        }
    }
}