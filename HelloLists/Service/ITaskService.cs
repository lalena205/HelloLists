using HelloLists.Model;
using System;
using System.Collections.Generic;

namespace HelloLists.Service
{
    public interface ITaskService
    {
        /// <summary>
        /// Interface describing Tasks operations
        /// </summary>
        IEnumerable<TaskItem> GetTasksForList(ListItem List);

        void TaskAdd(TaskItem newTask);

        void TaskUpdate(TaskItem existingTask);

        void TaskRemove(TaskItem item);
    }
}
