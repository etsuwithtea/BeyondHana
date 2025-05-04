namespace BeyondHana.Views;
using BeyondHana.ViewModels;
using CommunityToolkit.Maui.Views;
using Plugin.Maui.Audio;

public partial class TitlePage : ContentPage
{
    private IAudioManager audioManager = AudioManager.Current;
    private IAudioPlayer player;
    public TitlePage()
	{
		InitializeComponent();

        // Set binding context to CombinedVM
        BindingContext = App.CombinedVM;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void StartButton_Clicked(object sender, EventArgs e)
    {       
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Navigate to the HomePage
        await Navigation.PushAsync(new Views.HomePage());
    }

    // Sound effect
    private async Task PlaySoundAsync(string fileName, double volume)
    {
        var player = App.CombinedVM.AudioPlayer.PlayAudioAsync(fileName, volume);
        if (player == null) return;
    }
}