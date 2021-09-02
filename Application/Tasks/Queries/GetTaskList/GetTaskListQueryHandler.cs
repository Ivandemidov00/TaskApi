using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQueryHandler:IRequestHandler<GetTaskListQuery,TaskListVM>
    {
        private readonly ITaskDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(ITaskDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskListVM> Handle(GetTaskListQuery request,
            CancellationToken cancellationToken)
        {
            var taskQuery = await _dbContext
                .Tasks
                .ProjectTo<TaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new TaskListVM { Tasks = taskQuery };
        } 
    }
}