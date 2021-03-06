﻿using SQLite;
using System;
using System.ComponentModel;
using HelloTasks.ViewModel;

namespace HelloLists.Model
{
    /// <summary>
    /// Model class used to store List item in database
    /// </summary>
    public class ListItem
    {
        [PrimaryKey]
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

        public ListSortType SortBy { get; set; }
    }
}