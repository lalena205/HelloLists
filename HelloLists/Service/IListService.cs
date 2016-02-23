using HelloLists.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLists.Service
{
    interface IListService
    {
        IEnumerable<ListItem> GetAllLists(string sortField);

        void ListAdd(ListItem newList);

        void ListUpdate(ListItem existingList);
        void ListRemove(ListItem existingList);
    }
}
