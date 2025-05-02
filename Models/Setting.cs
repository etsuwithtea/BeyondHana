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
    }
}
