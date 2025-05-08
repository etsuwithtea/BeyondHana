using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Threading;

namespace BeyondHana.Views;

public partial class PlayPage : ContentPage
{
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    public PlayPage()
	{
		InitializeComponent();

        // set button to clickable
        NewGameButton.Pressed += NewGameButton_Pressed;
        NewGameButton.Released += NewGameButton_Released;
        ContinueButton.Pressed += ContinueButton_Pressed;
        ContinueButton.Released += ContinueButton_Released;
        LoadGameButton.Pressed += LoadGameButton_Pressed;
        LoadGameButton.Released += LoadGameButton_Released;
        BackButton.Pressed += BackButton_Pressed;
        BackButton.Released += BackButton_Released;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }


    private void NewGameButton_Pressed(object sender, EventArgs e)
    {   
        // Animation Clicked
        var button = sender as ImageButton;
        button.Source = "NewGame1_button.png";
        button.WidthRequest = 230;
        PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        button.HeightRequest = 65;

        // Change the grid size of the row
        ChangeGridSizeRow1();
    }
    private async void NewGameButton_Released(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);
        await Task.Delay(100);

        // Reset the button appearance
        button.Source = "NewGame2_button.png";
        button.WidthRequest = 147;
        button.HeightRequest = 65;

        // Change the grid size of the row
        ChangeGridSizeBack();

        // Navigate to the StoryPage
        StoryPage.currentChapter = 0;
        await Navigation.PushAsync(new Views.StoryPage());
    }


    private void ContinueButton_Pressed(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        button.Source = "Continue1_button.png";
        button.WidthRequest = 230;
        PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        button.HeightRequest = 65;

        // Change the grid size of the row
        ChangeGridSizeRow2();
    }
    private async void ContinueButton_Released(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);
        await Task.Delay(100);

        // Reset the button appearance
        button.Source = "Continue2_button.png";
        button.WidthRequest = 147;
        button.HeightRequest = 65;

        // Change the grid size of the row
        ChangeGridSizeBack();

        ToastDuration duration = ToastDuration.Short;
        Console.WriteLine(Preferences.Get("ChapterProgress", 0));
        if (Preferences.Get("ChapterProgress", 0) == 25)
        {
            var toast = Toast.Make("คุณไม่มีเกมที่เคยเล่นมาก่อนนะ", duration, 14);
            await toast.Show(cancellationTokenSource.Token);
        }
        else
        {
            StoryPage.currentChapter = Preferences.Get("ChapterProgress", 0);
            await Navigation.PushAsync(new Views.StoryPage());
        }                    
    }


    private void LoadGameButton_Pressed(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        button.Source = "LoadGame1_button.png";
        button.WidthRequest = 230;
        PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        button.HeightRequest = 65;

        ChangeGridSizeRow3();
    }
    private async void LoadGameButton_Released(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);
        await Task.Delay(100);

        // Reset the button appearance
        button.Source = "LoadGame2_button.png";
        button.WidthRequest = 147;
        button.HeightRequest = 65;

        // Change the grid size of the row
        ChangeGridSizeBack();

        // Navigate to the LoadAndSaveGamePage
        await Navigation.PushAsync(new Views.LoadAndSaveGamePage(true));
    }


    private void BackButton_Pressed(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        button.Source = "back2_label.png";
        PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
    }
    private async void BackButton_Released(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);
        await Task.Delay(100);
        // Reset the button appearance
        button.Source = "back1_label.png";

        // Navigate back to the previous page
        await Navigation.PopAsync();
    }


    // Change the grid size of the rows
    private async Task ChangeGridSizeRow1()
    {
        Row1.Height = new GridLength(0.7, GridUnitType.Star);
    }
    private async Task ChangeGridSizeRow2()
    {
        Row2.Height = new GridLength(0.7, GridUnitType.Star);
    }
    private async Task ChangeGridSizeRow3()
    {
        Row3.Height = new GridLength(0.7, GridUnitType.Star);
    }

    // Change the grid size back to normal
    private async Task ChangeGridSizeBack()
    {
        Row1.Height = new GridLength(0.45, GridUnitType.Star);
        Row2.Height = new GridLength(0.45, GridUnitType.Star);
        Row3.Height = new GridLength(0.45, GridUnitType.Star);
    }

    // Sound effect
    private async Task PlaySoundAsync(string fileName, double volume)
    {
        var player = App.CombinedVM.AudioPlayer.PlayAudioAsync(fileName, volume);
        if (player == null) return;
    }
}