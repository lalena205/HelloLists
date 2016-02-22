using HelloLists.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLists.Content
{
    public interface IDataService
    {
        /*
         * Task operations
        */
        IEnumerable<TaskItem> GetTasksForList(Guid ListId);
        void TaskAdd(TaskItem newTask);
        void TaskUpdate(TaskItem existingTask);

        /*
         * List operations
        */
        IEnumerable<ListItem> GetAllLists(string sortField);

        void ListAdd(ListItem newList);
        void ListUpdate(ListItem existingList);
        void ListRemove(ListItem existingList);
    }
}
