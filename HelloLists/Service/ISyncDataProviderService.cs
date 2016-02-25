using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloLists.Model.Sync;

namespace HelloLists.Service
{
    /// <summary>
    /// Network layer that will provide synchronizations between local and cloud storage 
    /// </summary>
    public interface ISyncDataProviderService
    {
        IEnumerable<SyncMessage> FetchUpdates(DateTime lastSucccesfulSync);
    }
}
