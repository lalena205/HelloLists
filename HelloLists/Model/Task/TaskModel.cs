using HelloLists.Model;
using HelloLists.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HelloTasks.Model
{
    class TaskModel
    {
        private ITaskService taskService { get; set; }
        private string _sortField;

        private ObservableCollection<TaskItem> tasks;

        public string SortField { get; set; }

        public ObservableCollection<TaskItem> Tasks
        {
            get { return this.tasks; }
        }

        public TaskModel()
        {
            this._sortField = "Title";

            InitializeTasks();            
        }  

        public void Add(TaskItem item)
        {
            this.tasks.Add(item);
            this.taskService.TaskAdd(item);
        }

        public void Remove(TaskItem item)
        {
            this.tasks.Remove(item);            
            this.taskService.TaskRemove(item);
        }
        
        private void InitializeTasks()
        {
            this.tasks = new ObservableCollection<TaskItem>(this.taskService.GetAllTasks(_sortField));
        }   
    }
}
