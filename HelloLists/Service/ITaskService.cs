﻿using HelloLists.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLists.Service
{
    interface ITaskService
    {
        IEnumerable<TaskItem> GetTasksForList(Guid ListId);
        void TaskAdd(TaskItem newTask);

        void TaskUpdate(TaskItem existingTask);
        void TaskRemove(TaskItem item);
        IEnumerable<TaskItem> GetAllTasks(string _sortField);
    }
}