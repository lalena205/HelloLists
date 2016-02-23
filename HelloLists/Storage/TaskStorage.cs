using HelloLists.ContentResoler;
using HelloLists.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HelloLists.Service
{
    class TaskStorage : ITaskStorage

    {
        [Dependency]
        private IDataAdapter<TaskItem> dataAdapter { get; set; }
               
        public IEnumerable<TaskItem> GetTasksForList(Guid ListId)
        {
            return new ObservableCollection<TaskItem>
            {
                new TaskItem
                {
                    Title = "task 1"
                },
                new TaskItem
                {
                    Title = "task 2"
                }
            };
        }

        public void TaskAdd(TaskItem newTask)
        {
            throw new NotImplementedException();
        }

        public void TaskUpdate(TaskItem existingTask)
        {
            throw new NotImplementedException();
        }
    }
}
