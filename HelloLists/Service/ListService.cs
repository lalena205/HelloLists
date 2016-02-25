using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloLists.Model;

namespace HelloLists.Service
{
    public class ListService : IListService
    {
        [Dependency]
        public IListStorage listStorage { get; set; }
        
        public IEnumerable<ListItem> GetExistingLists()
        {
            return this.listStorage.GetAvailableLists();
        }

        public void ListAdd(ListItem newList)
        {
            newList.IsDeleted = false;
            this.listStorage.ListAdd(newList);
        }

        public void ListRemove(ListItem existingList)
        {
            existingList.IsDeleted = true;
            existingList.LastModified = DateTime.Now;

            this.listStorage.ListUpdate(existingList);
        }

        public void ListUpdate(ListItem existingList)
        {
            existingList.LastModified = DateTime.Now;

            this.listStorage.ListUpdate(existingList);
        }
    }
}