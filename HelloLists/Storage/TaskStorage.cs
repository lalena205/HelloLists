using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using HelloLists.ContentResoler;
using HelloLists.Model;
using HelloLists.Service;

namespace HelloTasks.Service
{
    public class TaskStorage : ITaskStorage

    {
        private readonly Expression<Func<TaskItem, string>> orderByTitle = ti => ti.Title;
        private readonly Expression<Func<TaskItem, DateTime>> orderByCreationDate = ti => ti.CreatedOn;
        private readonly Expression<Func<TaskItem, DateTime>> orderByDueDate = ti => ti.DueDate;

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

        public IEnumerable<TaskItem> GetTasksForList(ListItem List)
        {
            Expression<Func<TaskItem, bool>> whereClause = ti => ti.ListId == List.Id;

            if( List.SortBy == ListSortType.CreationDate)
                return this.dataAdapter.Fetch(whereClause, this.orderByCreationDate);

            if( List.SortBy == ListSortType.Title)
                return this.dataAdapter.Fetch(whereClause, this.orderByTitle);

            return this.dataAdapter.Fetch(whereClause, this.orderByDueDate);
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
