using HelloLists.Base;
using HelloLists.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HelloLists.Model
{
    class ListModel
    {
        [Dependency]
        public IListService ListService { get; set; }
       
        private string _sortField;

        private ObservableCollection<ListItem> lists;

        public string SortField { get; set; }

        public ObservableCollection<ListItem> Lists
        {
            get { return this.lists; }
        }
        
        public ListModel()
        {
            this.ListService = DependencyFactory.Resolve<IListService>();
            this._sortField = "Title";          
        }  

        public void Add(ListItem item)
        {
            this.lists.Add(item);
            this.ListService.ListAdd(item);
        }

        public void Remove(ListItem item)
        {
            this.lists.Remove(item);            
            this.ListService.ListRemove(item);
        }
        
        public void InitializeLists()
        {
            this.lists = new ObservableCollection<ListItem>(this.ListService.GetAllLists(_sortField));
        }   
    }
}
