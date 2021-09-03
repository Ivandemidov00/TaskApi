using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Task;

namespace Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler:IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskDbContext _dbContext;

        public UpdateTaskCommandHandler(ITaskDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateTaskCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Tasks.FirstOrDefaultAsync(task =>
                    task.ID == request.ID, cancellationToken);

            if (entity == null || entity.ID != request.ID)
            {
                throw new NotFoundException(nameof(Task), request.ID);
            }

            entity.StatusId = request.Status;
            entity.Description = request.Description;
            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        
    }
}