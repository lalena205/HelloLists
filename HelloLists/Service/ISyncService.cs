using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloLists.Model.Sync;

namespace HelloLists.Service
{
    public interface ISyncService : IDisposable
    {
        void Start();

        void AddUpdateHandler(Action<SyncMessage> handler);

        void SendUpdate(SyncMessage syncMessage);
    }
}
