using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI.Core;
using HelloLists;
using HelloLists.Base;
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

        // This will receive a presorted task list; will have special methods for add, update & delete based on the sort field
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public ListItem ParentList { get; set; }

        public TaskViewModel(ISyncService syncService, ITaskService taskService)
        {
            _syncService = syncService;
            _syncService.AddUpdateHandler(SyncUpdateHandler);

            dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;

            this.taskService = taskService;
            SetTasksforList();
        }

        public void SetTasksforList()
        {
            if (this.ParentList != null)
            {
                if (this.Tasks == null)
                {
                    this.Tasks = new ObservableCollection<TaskItem>(this.taskService.GetTasksForList(this.ParentList));
                }
                else
                {
                    this.Tasks.Clear();
                    foreach (var task in this.taskService.GetTasksForList(this.ParentList))
                    {
                        this.Tasks.Add(task);
                    }
                }
            }
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
            if (sender == SenderType.SyncService)
            {
                // using dispatcher because Tasks object will be updated in the UI thread from sync service, hich runs in background
                dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    this.Tasks.Add(item);
                });
            }
            else
            {
                // we need to add sorted, so we find the position where to insert the element in the UI
                int index;
                switch (this.ParentList.SortBy)
                {
                    case ListSortType.DueDate:

                        index = this.Tasks.Select(t => t.CreatedOn).ToList().BinarySearch(item.DueDate);
                        break;
                    case ListSortType.Title:
                        index = this.Tasks.Select(t => t.Title).ToList().BinarySearch(item.Title);
                        break;
                    default:
                        index = this.Tasks.Select(t => t.CreatedOn).ToList().BinarySearch(item.CreatedOn);
                        break;
                }
                
                if (index < 0) index = ~index;
                this.Tasks.Insert(index, item);
                
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
            this.taskService.TaskAdd(item);
        }

        public void RemoveTask(TaskItem item)
        {
            this.Tasks.Remove(item);
            // TODO
        }

        public void SortTaskBy(ListSortType sortField)
        {
            this.ParentList.SortBy = sortField;

            // Sort the list according to the new sorting order to update the UI
            SetTasksforList();

            // Update list in db and synchronize update to persist sorting direction 
            //this.ListService.ListUpdate(this.ParentList);
            this._syncService.SendUpdate(new SyncMessage
            {
                Type = UpdateType.Update,
                Timestamp = DateTime.Now,
                Data = new ListItemUpdate()
                {
                    Item = this.ParentList
                }
            });
        }
    }
}
