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
        private bool working = false;
        private TaskViewModel TaskView { get; set; }

        public TaskPage()
        {
            this.InitializeComponent();
            TaskView = App.AppTasksModel;

            InitializeControls();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                this.TaskView.ParentList = e.Parameter as ListItem;
                if (this.TaskView.ParentList == null)
                {
                    return;
                }

                this.TaskView.Tasks = null;
                this.TaskView.SetTasksforList();
            }
        }

        private void InitializeControls()
        {
            BtnAddTask.Click += btnAddTask_Click;
            
            TxtAddNewTask.KeyDown += txtAddNewTask_KeyDown;
            BtnSortTasks.Click += btnSortTasks_Click;
        }

        private void btnSortTasks_Click(object sender, RoutedEventArgs e)
        {
            if (this.TaskView.ParentList.SortBy == ListSortType.CreationDate)
            {
                this.TaskView.SortTaskBy(ListSortType.Title);
            }
            else
            {
                this.TaskView.SortTaskBy(ListSortType.CreationDate);
            }
        }

        private void txtAddNewTask_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (working)
            {
                return;
            }

            this.working = true;

            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                e.Handled = true;

                AddTaskToList();
            }
            this.working = false;
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            if (working)
            {
                return;
            }

            this.working = true;
            AddTaskToList();
            this.working = false;
        }

        private void AddTaskToList()
        {
            TaskItem currentTask = new TaskItem
            {
                Id = new Guid(),
                Title = TxtAddNewTask.Text,
                CreatedOn = DateTime.Now,
                LastModified = DateTime.Now,
                LastUpdated = DateTime.MinValue,
                DueDate =  DateTime.MaxValue,
                ListId = this.TaskView.ParentList.Id
            };

            TaskView.AddTask(currentTask, SenderType.User);
            TxtAddNewTask.Text = string.Empty;
        }
    }
}
