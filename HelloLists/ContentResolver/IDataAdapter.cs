using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HelloLists.ContentResoler
{
    /// <summary>
    /// Generic SQLite adapter
    /// Performs basic operations on SQLite database
    /// </summary>
    /// <typeparam name="T">Generic type T indicating table to read form</typeparam>
    public interface IDataAdapter<T>
    {
        List<T> Fetch(Expression<Func<T, bool>> whereCondition);

        List<T> Fetch(Expression<Func<IComparable>> orderByExpression);

        List<T> Fetch(Expression<Func<T, bool>> whereCondition, Expression<Func<IComparable>> orderByExpression);

        List<T> Fetch();

        void Insert(T newEntry);

        void Update(T newEntry);

        void Delete(T newEntry);
    }
}
