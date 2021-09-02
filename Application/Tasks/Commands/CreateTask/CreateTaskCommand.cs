using System;
using Domain;
using MediatR;

namespace Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand:IRequest<Int32>
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public Int32 Status { get; set; }
    }
}