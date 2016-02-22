using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloLists.Model;
using System.Collections.ObjectModel;

namespace HelloLists.Content
{
    public class DataService : IDataService
    {
        private IDataAdapter dataAdapter;

        public IEnumerable<ListItem> GetAllLists(string sortField)
        {
            //throw new NotImplementedException();
            return new ObservableCollection<ListItem>
            {
                new ListItem
                {
                    Title = "b prima lista",
                    CreatedOn = DateTime.Now,
                },
                new ListItem
                {
                    Title = "asta e a doua",
                    CreatedOn = DateTime.Now,
                },
                new ListItem
                {
                    Title = "ultima",
                    CreatedOn = DateTime.Now,
                }
            };
        }

        public void ListAdd(ListItem newList)
        {
            //throw new NotImplementedException();
        }

        public void ListUpdate(ListItem existingList)
        {
            throw new NotImplementedException();
        }
        public void ListRemove(ListItem existingList)
        {
            throw new NotImplementedException();
        }

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
