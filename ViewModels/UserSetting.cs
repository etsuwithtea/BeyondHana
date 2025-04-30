using BeyondHana.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace BeyondHana.ViewModels
{
    public partial class UserSetting : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Models.Setting> activeSetting;

        public Models.Setting SelectedSetting => activeSetting.FirstOrDefault();

        public UserSetting()
        {
            activeSetting = new ObservableCollection<Models.Setting>(GetUserSetting());
        }

        private ObservableCollection<Setting> GetUserSetting()
        {
            return new ObservableCollection<Setting> {new Setting {  
                    Backgroundmusicpercent = 100,
                    Soundeffectpercent = 100,
                    Textsize = 10 //เดี๋ยวค่อยมาแก้ Default
                }
                
            };
        }
    }
}
