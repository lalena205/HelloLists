using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HelloLists.ContentResoler;
using SQLite;

namespace HelloLists.ContentResolver
{
    /// <summary>
    /// Generic SQLite adapter
    /// Performs basic operations on SQLite database
    /// </summary>
    /// <typeparam name="T">Generic type T indicating table to read form</typeparam>
    public class DataAdapter<T> : IDataAdapter<T>
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

        public List<T> Fetch(Expression<Func<T, bool>> whereCondition, Expression<Func<T, DateTime>> orderByExpression)
        {
            var entities = new List<T>();

            using (var db = new SQLiteConnection(SQLiteHelper.DBPath))
            {
                var query = db.Table<T>().Where(whereCondition).OrderBy(orderByExpression);
                entities.AddRange(query);
            }
            return entities;
        }

        public List<T> Fetch(Expression<Func<T, bool>> whereCondition, Expression<Func<T, string>> orderByString)
        {
            var entities = new List<T>();

            using (var db = new SQLiteConnection(SQLiteHelper.DBPath))
            {
                var query = db.Table<T>().Where(whereCondition).OrderBy(orderByString);
                entities.AddRange(query);
            }
            return entities; ;
        }

        public List<T> Fetch(Expression<Func<T, bool>> whereCondition, Expression<Func<T, int>> orderByInt)
        {
            var entities = new List<T>();

            using (var db = new SQLiteConnection(SQLiteHelper.DBPath))
            {
                var query = db.Table<T>().Where(whereCondition).OrderBy(orderByInt);
                entities.AddRange(query);
            }
            return entities; ;
        }

        public List<T> Fetch()
        {            
            var entities = new List<T>();

            using (var db = new SQLiteConnection(SQLiteHelper.DBPath))
            {
                var query = db.Table<T>();
                entities.AddRange(query);
            }
            return entities;
        }

        public List<T> Fetch(Expression<Func<T, bool>> whereCondition)
        {
            var entities = new List<T>();

            using (var db = new SQLiteConnection(SQLiteHelper.DBPath))
            {
                var query = db.Table<T>().Where(whereCondition);
                entities.AddRange(query);
            }
            return entities;
        }

        public List<T> Fetch(Expression<Func<IComparable>> orderByExpression)
        {
            throw new NotImplementedException();
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
