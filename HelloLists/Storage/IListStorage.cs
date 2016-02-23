using HelloLists.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLists.Service
{
    interface IListStorage
    {
        //use datalistitem and in serices make transition from datalistitem to listitem
        IEnumerable<ListItem> GetAllLists(string sortField);

        void ListAdd(ListItem newList);

        void ListUpdate(ListItem existingList);
        void ListRemove(ListItem existingList);
        void MarkAsDeleted(ListItem existingList);
        void UpdateField(ListItem existingList, string v1, string v2);
    }
}
