using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Core;
using HelloLists;
using HelloLists.Model;
using HelloLists.Model.Sync;
using HelloLists.Service;
using Microsoft.Practices.Unity;

namespace HelloTasks.ViewModel
{
    /// <summary>
    /// Central model to handle tasks. Comunicates with UI, Sync Service and database
    /// </summary>
    public class TaskViewModel
    {
        private readonly ISyncService _syncService;
        private readonly ITaskService taskService;
        private readonly CoreDispatcher dispatcher;

        // This will receive a presorted task list; will have special methods fr add, insert delete based on the sort field
        public ObservableCollection<TaskItem> Tasks { get; set; }
        public Guid ListId { get; set; }
        
        public TaskViewModel(ISyncService syncService, ITaskService taskService)
        {
            _syncService = syncService;
            _syncService.AddUpdateHandler(SyncUpdateHandler);

            dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;

            this.taskService = taskService;
            this.Tasks = new ObservableCollection<TaskItem>(this.taskService.GetTasksForList(this.ListId));
        }

        private void SyncUpdateHandler(SyncMessage message)
        {
            var update = message.Data as TaskItemUpdate;
            if (update == null)
            {
                return;
            }

            switch (message.Type)
            {
                case UpdateType.Add:
                    this.AddTask(update.Item, SenderType.SyncService);
                    break;
            }
        }

        public void AddTask(TaskItem item, SenderType sender)
        {
            dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.Tasks.Add(item);
            });

            this.taskService.TaskAdd(item);

            if (sender != SenderType.SyncService)
            {
                this._syncService.SendUpdate(new SyncMessage
                {
                    Type = UpdateType.Add,
                    Timestamp = item.CreatedOn,
                    Data = new TaskItemUpdate
                    {
                        Item = item
                    }
                });
            }
        }

        public void RemoveTask(TaskItem item)
        {
            this.Tasks.Remove(item);
            // TODO
        }
    }
}
