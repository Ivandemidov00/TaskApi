using System;
using Domain;
using MediatR;

namespace Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand:IRequest
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Status Status { get; set; }
    }
}