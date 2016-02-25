using HelloLists.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLists.Service
{
    /// <summary>
    /// Interface describing Lists operations
    /// </summary>
    public interface IListService
    {
        IEnumerable<ListItem> GetExistingLists();

        void ListAdd(ListItem newList);

        void ListUpdate(ListItem existingList);

        void ListRemove(ListItem existingList);
    }
}
