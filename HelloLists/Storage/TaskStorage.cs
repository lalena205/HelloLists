using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using HelloLists.ContentResoler;
using HelloLists.Model;
using HelloLists.Service;

namespace HelloTasks.Service
{
    public class TaskStorage : ITaskStorage

    {
        [Dependency]
        public IDataAdapter<TaskItem> dataAdapter { get; set; }

        public IEnumerable<TaskItem> GetAllTasks()
        {
            return this.dataAdapter.Fetch();
        }
        public IEnumerable<TaskItem> GetAvailableTasks()
        {
            Expression<Func<TaskItem, bool>> ex = li => li.IsDeleted == false;

            return this.dataAdapter.Fetch(ex);
        }

        public IEnumerable<TaskItem> GetTasksForList(Guid ListId)
        {
            Expression<Func<TaskItem, bool>> whereClause = ti => ti.ListId == ListId;

            return this.dataAdapter.Fetch(whereClause);
        }

        public void TaskAdd(TaskItem newTask)
        {
            this.dataAdapter.Insert(newTask);
        }

        public void TaskUpdate(TaskItem existingTask)
        {
            this.dataAdapter.Update(existingTask);
        }
        public void TaskRemove(TaskItem existingTask)
        {
            existingTask.IsDeleted = true;
            this.dataAdapter.Update(existingTask);
        }
    }
}
