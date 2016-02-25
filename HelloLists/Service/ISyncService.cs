using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloLists.Model.Sync;

namespace HelloLists.Service
{
    /// <summary>
    /// Synchronization service
    /// Gets updates fron SyncDataProvider, parses data and updates Local Models
    /// Invoked by Local Models when models are changed to send updates on cloud
    /// </summary>
    public interface ISyncService : IDisposable
    {
        void Start();

        void AddUpdateHandler(Action<SyncMessage> handler);

        void SendUpdate(SyncMessage syncMessage);
    }
}
