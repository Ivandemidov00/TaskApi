using System;
using Domain;
using MediatR;

namespace Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand:IRequest
    {
       public Int32 ID { get; set; }
       public Status Status { get; set; }
    }
}