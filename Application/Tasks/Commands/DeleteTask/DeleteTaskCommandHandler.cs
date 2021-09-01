using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Task = Domain.Task;

namespace Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler:IRequest<DeleteTaskCommand>
    {
        private readonly ITaskDbContext _dbContext;

        public DeleteTaskCommandHandler(ITaskDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteTaskCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tasks
                .FindAsync(new object[] { request.ID }, cancellationToken);

            if (entity == null || entity.ID != request.ID)
            {
                throw new NotFoundException(nameof(Task), request.ID);
            }

            _dbContext.Tasks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}