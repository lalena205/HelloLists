using System;

namespace HelloLists.Model.Sync
{
    /// <summary>
    /// Model for synchronization betweek local db and central storage (cloud database)
    /// </summary>
    public class SyncMessage
    {
        public DateTime Timestamp { get; set; }

        public UpdateType Type { get; set; }

        public AbstractUpdate Data { get; set; }
    }
}