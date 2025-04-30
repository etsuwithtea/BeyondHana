using CommunityToolkit.Mvvm.ComponentModel;
namespace BeyondHana.Models
{
    public partial class Setting : ObservableObject
    {
       
        [ObservableProperty]
        private int backgroundmusicpercent;
        [ObservableProperty]
        private int soundeffectpercent;
        [ObservableProperty]
        private int textsize;
    }
}
