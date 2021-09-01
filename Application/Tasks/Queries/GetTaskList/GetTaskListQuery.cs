using System;
using MediatR;

namespace Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQuery:IRequest<TaskListVM>
    {
        public Int32 ID { get; set; }
    }
}