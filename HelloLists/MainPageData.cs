using HelloLists.Base;
using HelloLists.Model;
using HelloLists.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HelloLists
{
    class MainPageData
    {
        private ObservableCollection<ListItem> lists;

        [Dependency]
        private IListService ListService { get; set; }

        public ListModel ListModel
        {
            get
            {
                if (this.lists == null)
                {
                    InitializeLists();
                }
                return new ListModel { Lists = lists };
            }
        }
        public string  SelectedList{
            get
            {
                return "test";
            }
        }  
              
        public ObservableCollection<ListItem> Lists
        {
            get { return this.lists; }
        }

        public MainPageData()
        {
            this.ListService = DependencyFactory.Resolve<IListService>();
        }

        public void AddList(ListItem item)
        {
            this.lists.Add(item);
            this.ListService.ListAdd(item);
        }

        public void RemoveList(ListItem item)
        {
            this.lists.Remove(item);
            this.ListService.ListRemove(item);
        }

        public void InitializeLists()
        {
            this.lists = new ObservableCollection<ListItem>(this.ListService.GetExistingLists());
        }
    }
}
