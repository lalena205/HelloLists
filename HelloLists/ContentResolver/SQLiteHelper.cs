﻿using HelloLists.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLists.ContentResoler
{
    class SQLiteHelper
    {
        public static string DBPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "hellolists.s3db");

        public void Init()
        {            
            // Initialize the database if necessary
            using (var db = new SQLite.SQLiteConnection(DBPath))
            {
                //db.DeleteAll<ListItem>();
                //db.DeleteAll<TaskItem>();

                if ( db.CreateTable<ListItem>() > 0)
                {
                    LoadInitialData();
                }

                db.CreateTable<TaskItem>();
            }
        }

        private void LoadInitialData()
        {
            using (var db = new SQLite.SQLiteConnection(DBPath))
            {
                ListItem li = new ListItem
                {
                    Id = Guid.NewGuid(),
                    Title = "Books",
                    CreatedOn = DateTime.Now,
                    SortBy = ListSortType.CreationDate
                };

                db.Insert(li);
                li = new ListItem
                {
                    Id = Guid.NewGuid(),
                    Title = "Movies",
                    CreatedOn = DateTime.Now,
                    SortBy = ListSortType.CreationDate
                };
                db.Insert(li);

                li = new ListItem
                {
                    Id = Guid.NewGuid(),
                    Title = "Songs",
                    CreatedOn = DateTime.Now,
                    SortBy = ListSortType.CreationDate
                };
                db.Insert(li);                
            }
        }
    }
}
