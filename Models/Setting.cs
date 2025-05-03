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


        // This method is called when the Textsize property changes
        partial void OnTextsizeChanged(int value)
        {
            Preferences.Set("Textsize", value);
        }
        // This method is called when the BackgroundMusicPercent property changes
        partial void OnBackgroundmusicpercentChanged(double value)
        {
            Preferences.Set("BackgroundMusicPercent", value);
        }
        // This method is called when the SoundEffectPercent property changes
        partial void OnSoundeffectpercentChanged(double value)
        {
            Preferences.Set("SoundEffectPercent", value);
        }
    }
}
