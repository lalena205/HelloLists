using System;

namespace HelloLists.Model.Sync
{
    public class SyncMessage
    {
        public DateTime Timestamp { get; set; }

        public UpdateType Type { get; set; }

        public AbstractUpdate Data { get; set; }
    }
}