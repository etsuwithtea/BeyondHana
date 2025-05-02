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

        // Play sound effect
        var combinedVM = BindingContext as CombinedVM;
        if (combinedVM == null) return;
        var setting = combinedVM.UserSetting.SelectedSetting;
        if (setting == null) return;
        
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", setting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

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