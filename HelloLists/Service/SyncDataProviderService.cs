using System;
using System.Collections.Generic;
using HelloLists.Model;
using HelloLists.Model.Sync;

namespace HelloLists.Service
{
    /// <summary>
    ///  Dummy implementation for testing pursope
    /// It works !
    /// </summary>
    class SyncDataProviderService : ISyncDataProviderService
    {
        public IEnumerable<SyncMessage> FetchUpdates(DateTime lastSucccesfulSync)
        {
            if (DateTime.Now.Second%30 == 0)
            {
                return new List<SyncMessage>
                {
                    new SyncMessage
                    {
                        Timestamp = DateTime.Now,
                        Type = UpdateType.Add,
                        Data = new TaskItemUpdate
                        {
                            Item = new TaskItem()
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
