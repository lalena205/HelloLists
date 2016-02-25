namespace HelloLists.Model
{
    using SQLite;
    using System;
    public class TaskItem
	{
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
	}
}