using HelloLists.Base;
using HelloLists.ContentResoler;
using HelloLists.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLists.Service
{
    class ListStorage : IListStorage
    {
        [Dependency]
        public IDataAdapter<ListItem> dataAdapter { get; set; }

        public IEnumerable<ListItem> GetAllLists()
        {
            return this.dataAdapter.Fetch();
        }
        public IEnumerable<ListItem> GetAvailableLists()
        {
            return this.dataAdapter.Fetch( /*li => !((ListItem)li).IsDeleted*/);
        }

        public void ListAdd(ListItem newList)
        {
            this.dataAdapter.Insert(newList);
        }

        public void ListUpdate(ListItem existingList)
        {
            this.dataAdapter.Update(existingList);
        }
        public void ListRemove(ListItem existingList)
        {
            existingList.IsDeleted = true;
            this.dataAdapter.Update(existingList);
        }        
    }
}
