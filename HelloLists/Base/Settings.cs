using System;
using System.ComponentModel;
using System.IO;
using Windows.Storage;

namespace HelloLists.Base
{
    class Settings : ObservableObject
    {
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;
        private readonly StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        bool _notificationsEnabled = true;
        string _connectionString = Path.Combine(ApplicationData.Current.LocalFolder.Path, "tasks.json");

        public bool NotificationsEnabled
        {
            get { return this._notificationsEnabled;  }
            set
            {
                if ( base.Set(ref _notificationsEnabled, value))
                {
                    _localSettings.Values[nameof(NotificationsEnabled)] = value;
                }
            }
        }

        public string ConnectionString
        {
            get { return this._connectionString; }
            set
            {
                if (base.Set(ref _connectionString, value))
                {
                    _localSettings.Values[nameof(ConnectionString)] = value;
                }
            }
        }

        public Settings()
        {
            this.LoadSettings();
        }

        private void LoadSettings()
        {
            var notificationsEnabled = _localSettings.Values[nameof(NotificationsEnabled)];
            if (notificationsEnabled != null)
            {
                this._notificationsEnabled = (bool)notificationsEnabled;
            }
        }        
    }
}
