using BeyondHana.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace BeyondHana.ViewModels
{
    public partial class SettingVM : ObservableObject
    {
        // ObservableCollection to hold the settings
        [ObservableProperty]
        private ObservableCollection<Setting> defaultSetting;

        // Property to get the selected setting
        public Setting SelectedSetting => defaultSetting.FirstOrDefault();

        // Singleton pattern to ensure only one instance of SettingVM exists
        private static SettingVM _instance;
        public static SettingVM Instance => _instance ??= new SettingVM();

        // Constructor
        public SettingVM()
        {
            defaultSetting = GetUserSetting();
        }

        // Method to get the user settings
        private ObservableCollection<Setting> GetUserSetting()
        {
            return new ObservableCollection<Setting> {new Setting {
                Backgroundmusicpercent = Preferences.Get("BackgroundMusicPercent", 0.7),
                Soundeffectpercent = Preferences.Get("SoundEffectPercent", 1.0),
                Textsize = Preferences.Get("Textsize", 18)
            }};
        }
    }
}