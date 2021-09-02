using System;
using System.Threading.Tasks;
using Application.Tasks.Commands.CreateTask;
using Application.Tasks.Commands.DeleteTask;
using Application.Tasks.Commands.UpdateTask;
using Application.Tasks.Queries.GetTaskDetails;
using Application.Tasks.Queries.GetTaskList;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class TaskController:BaseController
    {
        private readonly IMapper _mapper;

        public TaskController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<TaskListVM>> GetAll()
        {
            var query = new GetTaskListQuery
            {
                ID = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDetailsVm>> Get(Int32 id)
        {
            var query = new GetTaskDetailsQuery
            { 
                id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTaskDto createTaskDto)
        {
            var command = _mapper.Map<CreateTaskCommand>(createTaskDto);
            //command.Status = stat;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTaskDto updateTaskDto)
        {
            var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
            command.ID = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTaskCommand()
            {
                ID = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}