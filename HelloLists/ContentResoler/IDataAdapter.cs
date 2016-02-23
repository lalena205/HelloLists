using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLists.ContentResoler
{
    interface IDataAdapter<T>
    {
        List<T> Fetch(Func<T, bool> whereCondition);
        List<T> Fetch();

        void Insert(T newEntry);

        void Update(T newEntry);

        void Delete(T newEntry);
        
    }
}
