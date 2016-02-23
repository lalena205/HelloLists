using System;

namespace HelloLists.Model
{
    public class ListItem
    {
        public Guid Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public DateTime CreatedOn
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
        public bool IsDeleted
        {
            get;
            set;
        }
    }
}