using System;
using System.ComponentModel;
using Windows.Storage;

namespace HelloLists.Base
{
    class Settings : ObservableObject
    {
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;
        private readonly StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        bool _notificationsEnabled = true;
        
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
