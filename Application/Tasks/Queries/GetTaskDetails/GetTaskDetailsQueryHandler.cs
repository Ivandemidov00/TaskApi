using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler:IRequestHandler<GetTaskDetailsQuery,TaskDetailsVm>
    {
        
        private readonly ITaskDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskDetailsQueryHandler(ITaskDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskDetailsVm> Handle(GetTaskDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tasks
                .FirstOrDefaultAsync(task =>
                    task.ID == request.id, cancellationToken);

            if (entity == null || entity.ID != request.id)
            {
                throw new NotFoundException(nameof(Task), request.id);
            }

            return _mapper.Map<TaskDetailsVm>(entity);
        }
    }
}