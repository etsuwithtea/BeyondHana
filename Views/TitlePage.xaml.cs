namespace BeyondHana.Views;
using BeyondHana.ViewModels;
using Microsoft.Maui.Storage;
using Plugin.Maui.Audio;
public partial class TitlePage : ContentPage
{
    private IAudioManager audioManager = AudioManager.Current;
    private IAudioPlayer player;
    public TitlePage()
	{
		InitializeComponent();

        // Set binding context to CombinedVM
        BindingContext = new CombinedVM();
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
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Play sound effect

        var combinedVM = BindingContext as CombinedVM;
        if (combinedVM == null) return;

        // Get the selected setting
        var setting = combinedVM.UserSetting.SelectedSetting;
        if (setting == null) return;

        await PlaySoundAsync("buttonclicksound.mp3", setting.Soundeffectpercent);
        //// Check if the sound effect is enabled
        //if (player == null)
        //{
        //    audioManager = AudioManager.Current;
        //    var stream = await FileSystem.OpenAppPackageFileAsync("buttonclicksound.mp3");
        //    player = audioManager.CreatePlayer(stream);
        //    player.Loop = false;
        //    player.Volume = 1.0;
        //}
        //else if(player != null)
        //{
        //    player.Volume = (setting.Soundeffectpercent) / 100;
        //}
        //player.Play();

        // Navigate to the HomePage
        await Navigation.PushAsync(new Views.HomePage());
    }

    private async Task PlaySoundAsync(string fileName, double volume)
    {
        // Stop and dispose old player if it exists
        player?.Stop();
        player?.Dispose();

        // Load new file and create player
        var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
        player = audioManager.CreatePlayer(stream);
        player.Volume = volume;
        player.Play();
    }
}