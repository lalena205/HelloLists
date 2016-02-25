using System;
using System.Collections.Generic;
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
using HelloLists.Model;
using HelloTasks.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloLists
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaskPage : Page
    {

        private ListItem parentList;
        private TaskViewModel TaskView { get; set; }

        public TaskPage()
        {
            this.InitializeComponent();
            TaskView = App.AppTasksModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                this.parentList = e.Parameter as ListItem;
                if (this.parentList == null)
                {
                    this.Hello.Text = "Sorry, there was an error;";
                    return;
                }

                this.Hello.Text = this.parentList.Title;
            }
        }
    }
}
