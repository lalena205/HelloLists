using HelloLists.Base;
using HelloLists.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HelloLists.Model
{
    public class ListModel
    {
        public string SortField { get; set; }

        public ObservableCollection<ListItem> Lists { get; set; }
    }
}
