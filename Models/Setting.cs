using CommunityToolkit.Mvvm.ComponentModel;
namespace BeyondHana.Models
{
    public partial class Setting : ObservableObject
    {
       
        [ObservableProperty]
        private double backgroundmusicpercent;

        [ObservableProperty]
        private double soundeffectpercent;

        [ObservableProperty]
        private int textsize;


        partial void OnTextsizeChanged(int value)
        {
            Preferences.Set("Textsize", value);
        }

        // จะถูกเรียกเมื่อ backgroundMusicPercent เปลี่ยน
        partial void OnBackgroundmusicpercentChanged(double value)
        {
            Preferences.Set("BackgroundMusicPercent", value);
        }

        // จะถูกเรียกเมื่อ soundEffectPercent เปลี่ยน
        partial void OnSoundeffectpercentChanged(double value)
        {
            Preferences.Set("SoundEffectPercent", value);
        }
    }
}
