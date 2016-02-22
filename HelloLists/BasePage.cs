using HelloLists.Content;
using Microsoft.Practices.Unity;
using Windows.UI.Xaml.Controls;
using System;
using HelloLists.Base;

namespace HelloLists
{
    public class BasePage : Page
    {

        private IDataService _dataService;

        [Dependency]
        protected IDataService DataService
        {
            get { return this._dataService; }
            set { this._dataService = value; }
        }

        public BasePage()
        {
            this._dataService = DependencyFactory.Resolve<IDataService>();
        }

    }
}
