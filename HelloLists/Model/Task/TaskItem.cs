using System.Collections;
using System.Collections.Generic;

namespace HelloLists.Model
{
    using SQLite;
    using System;
    public class TaskItem : IComparable<TaskItem>
    {
        private class sortAscendingByTitle : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                return string.Compare(((TaskItem)a).Title, ((TaskItem)b).Title, StringComparison.OrdinalIgnoreCase);
            }
        }

        [PrimaryKey]
		public Guid Id 
		{
			get;
			set;
		}

		public Guid ListId
		{
			get;
			set;
		}

		public string Title 
		{
			get;
			set;
		}

		public string Note
		{
			get;
			set;
		}

		public DateTime DueDate 
		{
			get;
			set;
		}

		public bool Completed
		{
			get;
			set;
		}

		public DateTime CreatedOn
		{
			get;
			set;
		}

		public string Tags
		{
			get;
			set;
		}

		public DateTime LastModified
		{
			get;
			set;
		}

		public DateTime LastUpdated
        {
            get;
            set;
        }

        public bool IsDeleted { get; set; }

        // Implement IComparable CompareTo to provide default sort order.
        public int CompareTo(TaskItem otherTask)
        {
            return DateTime.Compare(this.CreatedOn, otherTask.CreatedOn);
        }

        // Method to return IComparer object for sort helper.
        public static IComparer SortAscendingByTitle()
        {
            return (IComparer)new sortAscendingByTitle();
        }
    }
}