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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloLists
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        internal MainPageData PageData { get; set; }

        public ListItem SelectItem { get; set; }

        private ListItem currentList;
        public MainPage()
        {
            this.InitializeComponent();

            PageData = new MainPageData();

            this.InitializeControls();
        }

        private void InitializeControls()
        {
            txtAddNew.GotFocus += txtAddNew_GotFocus;
            txtAddNew.KeyDown += txtAddNew_KeyDown;

            btnAddList.Click += btnAddList_Click;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void btnAddList_Click(object sender, RoutedEventArgs e)
        {
            AddListToCollection();
        }

        private void RemoveListButton_Click(object sender, RoutedEventArgs e)
        {
            //currentList = sender.ListId;

            this.PageData.RemoveList(currentList);
        }

        private void txtAddNew_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                e.Handled = true;

                AddListToCollection();
            }
        }

        private void txtAddNew_GotFocus(object sender, RoutedEventArgs e)
        {
            txtAddNew.Text = string.Empty;
            txtAddNew.GotFocus -= txtAddNew_GotFocus;
        }

        private void AddListToCollection()
        {
            this.currentList = new ListItem
            {
                Id = new Guid(),
                Title = txtAddNew.Text,
                CreatedOn = DateTime.Now,
                LastModified = DateTime.Now,
                LastUpdated = DateTime.MinValue
            };

            PageData.AddList(currentList);

            txtAddNew.Text = string.Empty;
            ListView.SelectedItem = currentList;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //this.ListModel.CollectionChanged(e);
            //switch(sender)
            //{
            //    case AddListButton: {
            //        this.dataHelper.ListAdd(currentList);
            //        break;                    
            //    }
            //    case RemoveListButton: {
            //        this.dataHelper.RemoveList(currentList);
            //    }
            //}
        }

        private void btnAddList_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}