using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloLists.Model.Sync;

namespace HelloLists.Service
{
    public interface ISyncDataProviderService
    {
        IEnumerable<SyncMessage> FetchUpdates(DateTime lastSucccesfulSync);
    }
}
