using BeyondHana.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace BeyondHana.ViewModels
{
    public partial class SettingVM : ObservableObject
    {

        // Singleton pattern to ensure only one instance of SettingVM exists
        private static SettingVM _instance;
        public static SettingVM Instance => _instance ??= new SettingVM();

        // ObservableCollection to hold the settings
        [ObservableProperty]
        private ObservableCollection<Models.Setting> defaultSetting;

        // Property to get the selected setting
        public Models.Setting SelectedSetting => defaultSetting.FirstOrDefault();

        public SettingVM()
        {
            defaultSetting = new ObservableCollection<Models.Setting>(GetUserSetting());
        }

        // Method to get the user settings
        private ObservableCollection<Setting> GetUserSetting()
        {
            return new ObservableCollection<Setting> {
            new Setting {
                Backgroundmusicpercent = Preferences.Get("BackgroundMusicPercent", 1.0),
                Soundeffectpercent = Preferences.Get("SoundEffectPercent", 1.0),
                Textsize = Preferences.Get("Textsize", 14)
            }
        };
        }
    }
}
