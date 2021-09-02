using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler:IRequestHandler<CreateTaskCommand,Int32>
    {
        private readonly ITaskDbContext _dbContext;
        
        public CreateTaskCommandHandler(ITaskDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Int32> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
           /* var status = new Domain.Status()
            {
                Status_ID = request.Status,
            };*/
            var task = new Domain.Task()
            {
                Name = request.Name,
                Description = request.Description,
                Status = new Status {Status_ID = request.Status}
            };

            await _dbContext.Tasks.AddAsync(task, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task.ID;
        }
    }
}