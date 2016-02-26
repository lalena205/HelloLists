using HelloLists;
using HelloLists.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HelloLists.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloLists
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ListViewModel ListView { get; set; } 

        private ListItem currentList;
        private bool working = false;

        public MainPage()
        {
            this.InitializeComponent();
            
            ListView = App.AppListsModel; 

            this.InitializeControls();
        }

        private void InitializeControls()
        {
            TxtAddNew.KeyDown += txtAddNew_KeyDown;

            BtnAddList.Click += btnAddList_Click;
            BtnDeleteList.Click += btnDeleteList_Click;
            TodoListsView.SelectionChanged += TodoListsView_SelectionChanged;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void btnAddList_Click(object sender, RoutedEventArgs e)
        {
            if (working)
            {
                return;
            }

            this.working = true;
            AddListToCollection();
            this.working = false;
        }
        
        private void txtAddNew_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (working)
            {
                return;
            }

            this.working = true;

            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                e.Handled = true;

                AddListToCollection();
            }
            this.working = false;
        }
        
        private void TodoListsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.currentList = (ListItem)TodoListsView.SelectedItem;
            TasksFrame.Navigate(typeof(TaskPage), this.currentList);
        }

        private void btnDeleteList_Click(object sender, RoutedEventArgs e)
        {
            if (working)
            {
                return;
            }

            this.working = true;

            //frame does not refresh or navigate
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            ListView.RemoveList(this.currentList, SenderType.User);
            TasksFrame.Navigate(typeof(BlankPage));

            this.working = false;
        }

        private void AddListToCollection()
        {
            this.currentList = new ListItem
            {
                Id = Guid.NewGuid(),
                Title = TxtAddNew.Text,
                CreatedOn = DateTime.Now,
                LastModified = DateTime.Now,
                LastUpdated = DateTime.MinValue,
                SortBy = ListSortType.CreationDate
            };

            ListView.AddList(currentList, SenderType.User);
            TxtAddNew.Text = string.Empty;
        }
    }
}