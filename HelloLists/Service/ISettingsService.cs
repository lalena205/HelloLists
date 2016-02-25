using System;

namespace HelloLists.Service
{
    public interface ISettingsService
    {
        bool NotificationsEnabled { get; set; }

        string ConnectionString { get; set; }

        DateTime LastSuccesfulSync { get; set; }
    }
}