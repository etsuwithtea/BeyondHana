namespace BeyondHana.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

        // Set button events
        PlayButton.Pressed += PlayButton_Pressed;
        PlayButton.Released += PlayButton_Released;
        SettingButton.Pressed += SettingButton_Pressed;
        SettingButton.Released += SettingButton_Released;
        ExitButton.Pressed += ExitButton_Pressed;
        ExitButton.Released += ExitButton_Released;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    // Play button event handlers
    private async void PlayButton_Pressed(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        button.Source = "play1_button.png";      
        button.WidthRequest = 250;
        button.HeightRequest = 95;
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);

        await ChangeGridSizeRow1();
    }
    private async void PlayButton_Released(object sender, EventArgs e)
    {
        var button = sender as ImageButton;

        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);
        await Task.Delay(100);

        button.Source = "play2_button.png";
        button.WidthRequest = 150;
        button.HeightRequest = 65;

        await ChangeGridSizeBack();

        // Navigate to the PlayPage
        await Navigation.PushAsync(new Views.PlayPage());
    }


    // Setting button event handlers
    private async void SettingButton_Pressed(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        button.Source = "setting1_button.png";
        
        button.WidthRequest = 250;
        button.HeightRequest = 85;
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);

        await ChangeGridSizeRow2();
    }
    private async void SettingButton_Released(object sender, EventArgs e)
    {
        var button = sender as ImageButton;

        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);
        await Task.Delay(100);

        button.Source = "setting2_button.png";
        button.WidthRequest = 150;
        button.HeightRequest = 65;

        await ChangeGridSizeBack();

        // Navigate to the SettingPage
        await Navigation.PushAsync(new Views.SettingPage());
    }


    // Exit button event handlers
    private async void ExitButton_Pressed(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        button.Source = "exit1_button.png";       
        button.WidthRequest = 250;
        button.HeightRequest = 75;
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);

        await ChangeGridSizeRow3();
    }
    private async void ExitButton_Released(object sender, EventArgs e)
    {
        var button = sender as ImageButton;

        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);

        await Task.Delay(100);

        button.Source = "exit2_button.png";
        button.WidthRequest = 150;
        button.HeightRequest = 50;

        await ChangeGridSizeBack();

        // Navigate to the ClosePage
        await Navigation.PushAsync(new Views.ClosePage());
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