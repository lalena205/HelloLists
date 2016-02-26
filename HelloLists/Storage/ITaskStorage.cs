using HelloLists.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLists.Service
{
    /// <summary>
    /// /// Interface describing basic db operations for Tasks
    /// </summary>
    public interface ITaskStorage
    {
        IEnumerable<TaskItem> GetTasksForList(ListItem List);
        void TaskAdd(TaskItem newTask);

        void TaskUpdate(TaskItem existingTask);
    }
}
