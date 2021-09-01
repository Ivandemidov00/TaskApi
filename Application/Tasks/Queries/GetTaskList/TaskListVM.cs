using System.Collections.Generic;

namespace Application.Tasks.Queries.GetTaskList
{
    public class TaskListVM
    {
        public IList<TaskLookupDto> Tasks { get; set; }
    }
}