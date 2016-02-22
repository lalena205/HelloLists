using HelloLists.Base;
using HelloLists.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace HelloLists.Model
{
    class ListModel
    {
        private IDataService _dataService;
        private string _sortField;

        private ObservableCollection<ListItem> lists;

        public string SortField { get; set; }

        public ObservableCollection<ListItem> Lists
        {
            get { return this.lists; }
        }
        public ListModel()
        {
            this._dataService = DependencyFactory.Resolve<IDataService>();
            this._sortField = "Title";

            InitializeLists();            
        }  

        public void Add(ListItem item)
        {
            this.lists.Add(item);
            this._dataService.ListAdd(item);
        }

        public void Remove(ListItem item)
        {
            this.lists.Remove(item);            
            this._dataService.ListRemove(item);
        }
        
        private void InitializeLists()
        {
            this.lists = new ObservableCollection<ListItem>(this._dataService.GetAllLists(_sortField));
        }   
    }
}
