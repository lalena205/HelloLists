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
        //[Dependency]
        public IDataAdapter<ListItem> dataAdapter { get; set; }

        public IEnumerable<ListItem> GetAllLists(string sortField)
        {
            this.dataAdapter = DependencyFactory.Resolve<IDataAdapter<ListItem>>();
            return new ObservableCollection<ListItem>(this.dataAdapter.Read());
            
            //return new ObservableCollection<ListItem>
            //{
            //    new ListItem
            //    {
            //        Title = "b prima lista",
            //        CreatedOn = DateTime.Now,
            //    },
            //    new ListItem
            //    {
            //        Title = "asta e a doua",
            //        CreatedOn = DateTime.Now,
            //    },
            //    new ListItem
            //    {
            //        Title = "ultima",
            //        CreatedOn = DateTime.Now,
            //    }
            //};
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

        public void MarkAsDeleted(ListItem existingList)
        {
            throw new NotImplementedException();
        }

        public void UpdateField(ListItem existingList, string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
