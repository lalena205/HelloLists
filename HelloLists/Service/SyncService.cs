using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using HelloLists.Base;
using HelloLists.Model.Sync;
using Microsoft.Practices.Unity;

namespace HelloLists.Service
{
    /*
        This is a basic implementation of a synchronization background service.
        
        Proper implementation would use a similar model and register a Background task:
        https://msdn.microsoft.com/en-us/library/windows/apps/mt299100.aspx 
        https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundTask

    */
    public class SyncService : ISyncService
    {
        [Dependency]
        public ISyncDataProviderService SyncDataProviderService { get; set; }

        [Dependency]
        public ISettings Settings { get; set; }

        private Task syncThread;
        private List<Action<SyncMessage>> handlers;

        public SyncService()
        {
            this.handlers = new List<Action<SyncMessage>>();
        }

        public void Start()
        {
            syncThread = new Task(Synchronization);
            syncThread.Start();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private async void Synchronization()
        {
            while (true)
            {
                // Get only updates newer than lastSuccesful sync
                var updates = SyncDataProviderService.FetchUpdates(this.Settings.LastSuccesfulSync).ToList();

                if (updates != null)
                {
                    foreach (var update in updates)
                    {
                        foreach (var handler in handlers)
                        {
                            handler(update);
                        }
                    }

                    // If update fails in the network layer, then the lastSuccesfullSync should stay the same
                    // to make sure we din't miss updates
                    if (updates.Count > 0)
                    {
                        this.Settings.LastSuccesfulSync = DateTime.Now;
                    }
                }
                else
                {
                    //logg exception 
                }
                await Task.Delay(TimeSpan.FromMilliseconds(500));
            }
        }

        public void AddUpdateHandler(Action<SyncMessage> handler)
        {
            handlers.Add(handler);
        }

        public void SendUpdate(SyncMessage syncMessage)
        {
            ;
        }
    }
}