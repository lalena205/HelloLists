using System;
using System.IO;
using Windows.Storage;
using HelloLists.Base;

namespace HelloLists.Service
{
    public class Settings : ObservableObject, ISettingsService
    {
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;
        private readonly StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        bool _notificationsEnabled = true;
        string _connectionString = Path.Combine(ApplicationData.Current.LocalFolder.Path, "tasks.json");
        DateTimeOffset _lastSuccesfulSync = DateTimeOffset.MinValue;

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
            get
            {
                return this._connectionString;
            }
            set
            {
                if (base.Set(ref _connectionString, value))
                {
                    _localSettings.Values[nameof(ConnectionString)] = value;
                }
            }
        }

        public DateTime LastSuccesfulSync
        {
            get
            {
                return this._lastSuccesfulSync.DateTime;
            }
            set
            {
                if (base.Set(ref _lastSuccesfulSync, value))
                {
                    _localSettings.Values[nameof(LastSuccesfulSync)] = (DateTimeOffset)value;
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

            var lastSuccesfulSync = _localSettings.Values[nameof(LastSuccesfulSync)];
            if (lastSuccesfulSync != null)
            {
                this._lastSuccesfulSync = (DateTimeOffset)lastSuccesfulSync;
            }
        }    
    }
}