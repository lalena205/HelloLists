using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloLists.Model;

namespace HelloLists.Service
{
    class ListService : IListService
    {
        [Dependency]
        public IListStorage listStorage { get; set; }
        
        public ListService()
        {
        }
        public IEnumerable<ListItem> GetAllLists(string sortField)
        {
            return this.listStorage.GetAllLists(sortField);
        }

        public void ListAdd(ListItem newList)
        {
            this.listStorage.ListAdd(newList);
        }

        public void ListRemove(ListItem existingList)
        {
            this.listStorage.UpdateField(existingList, "IsDeleted", "1");
        }

        public void ListUpdate(ListItem existingList)
        {
            throw new NotImplementedException();
        }
    }
}