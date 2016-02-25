using HelloLists.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLists.Service
{
    public class TaskService : ITaskService
    {
        [Dependency]
        public ITaskStorage taskStorage { get; set; }

        [InjectionConstructor]
        public TaskService(ITaskStorage taskStorage)
        {
            this.taskStorage = taskStorage;
        }
        public IEnumerable<TaskItem> GetAllTasks(string _sortField)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskItem> GetTasksForList(Guid ListId, string _sortField)
        {
            return this.taskStorage.GetTasksForList(ListId);
        }

        public void TaskAdd(TaskItem newTask)
        {
            this.taskStorage.TaskAdd(newTask);
        }

        public void TaskRemove(TaskItem item)
        {
            throw new NotImplementedException();
        }

        public void TaskUpdate(TaskItem existingTask)
        {
            this.taskStorage.TaskUpdate(existingTask);
        }

        public IEnumerable<TaskItem> GetTasksForList(Guid ListId)
        {
            throw new NotImplementedException();
        }
    }
}
