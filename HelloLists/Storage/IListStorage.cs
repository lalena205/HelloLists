using HelloLists.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLists.Service
{
    /// <summary>
    /// Interface describing basic db operations for Lists
    /// </summary>
    public interface IListStorage
    {
        IEnumerable<ListItem> GetAllLists();

        IEnumerable<ListItem> GetAvailableLists();

        void ListAdd(ListItem newList);

        void ListUpdate(ListItem existingList);

        void ListRemove(ListItem existingList);
    }
}
