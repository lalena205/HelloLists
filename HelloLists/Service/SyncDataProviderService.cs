using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloLists.Model;
using HelloLists.Model.Sync;

namespace HelloLists.Service
{
    class SyncDataProviderService: ISyncDataProviderService
    {
        public IEnumerable<SyncMessage> FetchUpdates(DateTime lastSucccesfulSync)
        {
            if (DateTime.Now.Second%5 == 0)
            {
                return new List<SyncMessage>
                {
                    new SyncMessage
                    {
                        Timestamp = DateTime.Now,
                        Type = UpdateType.Add,
                        Data = new TaskItemUpdate
                        {
                            TaskUpdate = new TaskItem()
                            {
                                Title = "Blana"
                            }
                        }
                    }
                };
            }

            return new List<SyncMessage>();
        }
    }
}
