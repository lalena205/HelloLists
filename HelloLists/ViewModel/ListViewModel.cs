using System.Collections.ObjectModel;
using Windows.UI.Core;
using HelloLists.Model;
using HelloLists.Model.Sync;
using HelloLists.Service;

namespace HelloLists.ViewModel
{
    public class ListViewModel
    {
        private readonly ISyncService _syncService;

        private IListService listService;
        private CoreDispatcher dispatcher;

        public ObservableCollection<ListItem> Lists { get; set; }
        
        public ListViewModel(ISyncService syncService, IListService listService = null)
        {
            _syncService = syncService;
            _syncService.AddUpdateHandler(SyncUpdateHandler);

            dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;

            this.listService = listService;
            this.Lists = new ObservableCollection<ListItem>(this.listService.GetExistingLists());
        }

        private void SyncUpdateHandler(SyncMessage message)
        {
            var update = message.Data as ListItemUpdate;
            if (update == null)
            {
                return;
            }

            switch (message.Type)
            {
                case UpdateType.Add:
                    this.AddList(update.Item, SenderType.SyncService);
                    break;
            }
        }

        public void AddList(ListItem item, SenderType sender)
        {
            dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.Lists.Add(item);
            });

            this.listService.ListAdd(item);

            if (sender != SenderType.SyncService)
            {
                this._syncService.SendUpdate(new SyncMessage
                {
                    Type = UpdateType.Add,
                    Timestamp = item.CreatedOn,
                    Data = new ListItemUpdate
                    {
                        Item = item
                    }
                });
            }
        }

        public void RemoveList(ListItem item)
        {
            this.Lists.Remove(item);
            // TODO
        }


    }
}
