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
            TxtAddNew.GotFocus += txtAddNew_GotFocus;
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

        private void txtAddNew_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtAddNew.Text = string.Empty;
            TxtAddNew.GotFocus -= txtAddNew_GotFocus;
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

            //TODO doesn't work
            TasksFrame.Navigate(typeof(BlankPage));
            ListView.RemoveList(this.currentList, SenderType.User);

            this.working = false;
        }

        private void AddListToCollection()
        {
            this.currentList = new ListItem
            {
                Id = new Guid(),
                Title = TxtAddNew.Text,
                CreatedOn = DateTime.Now,
                LastModified = DateTime.Now,
                LastUpdated = DateTime.MinValue
            };

            ListView.AddList(currentList, SenderType.User);

            TxtAddNew.Text = string.Empty;
        }
    }
}