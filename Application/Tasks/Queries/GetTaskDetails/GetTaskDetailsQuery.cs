using System;
using Domain;
using MediatR;

namespace Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery:IRequest<TaskDetailsVm>
    {
        public Int32 id { get; set; }
        public Status Status { get; set; }
    }
}