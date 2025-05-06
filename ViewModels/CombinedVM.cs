using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondHana.ViewModels
{
    public partial class CombinedVM : ObservableObject
    {
        public SettingVM UserSetting => SettingVM.Instance;
        public AudioPlayerVM AudioPlayer { get; set; } = new AudioPlayerVM();
        public BGAudioPlayerVM BGAudioPlayer { get; set; } = new BGAudioPlayerVM();
        public SaveGameVM UserSaveGames { get; set; } = new SaveGameVM();

        // Constructor
        public CombinedVM()
        {
            if (UserSetting.SelectedSetting != null)
                UserSetting.SelectedSetting.PropertyChanged += SelectedSetting_PropertyChanged;
        }
        // This method is called when the selected setting changes
        private void SelectedSetting_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UserSetting.SelectedSetting.Backgroundmusicpercent))
            {
                BGAudioPlayer.SetVolume(UserSetting.SelectedSetting.Backgroundmusicpercent);
                //Console.WriteLine($"[Volume Changed] {UserSetting.SelectedSetting.Backgroundmusicpercent}");
            }
        }
    }
}