using HelloLists.Base;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HelloLists.ContentResoler
{
    class DataAdapter<T> : IDataAdapter<T>
        where T : new()
    {        
        public void Delete(T entry)
        {
            using (var db = new SQLiteConnection(SQLiteHelper.DBPath))
            {
                db.Delete<T>(entry);
            }
        }

        public void Insert(T newEntry)
        {
            using (var db = new SQLiteConnection(SQLiteHelper.DBPath))
            {
                db.Insert(newEntry);
            }
        }

        public List<T> Fetch()
        {
            //return Fetch(_ => true);
            var entities = new List<T>();

            using (var db = new SQLiteConnection(SQLiteHelper.DBPath))
            {
                var query = db.Table<T>();
                foreach (T entity in query)
                {
                    entities.Add(entity);
                }
            }
            return entities;
        }

        public List<T> Fetch(Func<T, bool> whereCondition)
        {
            var entities = new List<T>();

            using (var db = new SQLiteConnection(SQLiteHelper.DBPath))
            {
                var query = db.Table<T>().Where(t => whereCondition(t));
                foreach (T entity in query)
                {
                    entities.Add(entity);
                }
            }
            return entities;
        }

        public void Update(T newEntry)
        {
            using (var db = new SQLiteConnection(SQLiteHelper.DBPath))
            {
                db.InsertOrReplace(newEntry);
            }
        }
    }
}
