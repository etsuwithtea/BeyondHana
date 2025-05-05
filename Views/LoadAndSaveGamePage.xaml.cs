using BeyondHana.Data;
namespace BeyondHana.Views;

public partial class LoadAndSaveGamePage : ContentPage
{
    private bool CheckIsLoadGamePageOn;
	public LoadAndSaveGamePage(bool Check)
	{
		InitializeComponent();
        BackButton.Pressed += BackButton_Pressed;
        BackButton.Released += BackButton_Released;

        this.CheckIsLoadGamePageOn = Check;
        BindingContext = App.CombinedVM; 
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);

        VisibleConfig();
        UpdateSave();
    }

    // 
    private async void VisibleConfig()
    {
        var saveGames = App.CombinedVM.UserSaveGames.saveGames;
        if (CheckIsLoadGamePageOn == true)
        {
            Loadgame_label.IsVisible = true;
            Savegame_label.IsVisible = false;
            SaveButton1.IsVisible = false;
            SaveButton2.IsVisible = false;
            SaveButton3.IsVisible = false;
        }
        else if (CheckIsLoadGamePageOn == false)
        {
            Loadgame_label.IsVisible = false;
            Savegame_label.IsVisible = true;
            PlayButton1.IsVisible = false;
            PlayButton2.IsVisible = false;
            PlayButton3.IsVisible = false;
        }
    }

    // Update the save game status
    private async void UpdateSave()
    {
        var saveGames = App.CombinedVM.UserSaveGames.saveGames;
        if (saveGames.Count < 3)
        {
            return;
        }
        var gridLoads = new[] { GridLoad1, GridLoad2, GridLoad3 };
        var noLoads = new[] { NoLoad1, NoLoad2, NoLoad3 };
        if (CheckIsLoadGamePageOn == true)
        {
            for (int i = 0; i < 3; i++)
            {
                if (saveGames[i].isSave == "Yes")
                {
                    gridLoads[i].IsVisible = true;
                    noLoads[i].IsVisible = false;
                }
                else
                {
                    gridLoads[i].IsVisible = false;
                    noLoads[i].IsVisible = true;
                }
            }
        }
        if (CheckIsLoadGamePageOn == false)
        {
            for (int i = 0; i < 3; i++)
            {
                if (saveGames[i].isSave == "No")
                {
                    gridLoads[i].Opacity = 0.5;
                }
                else
                {
                    gridLoads[i].Opacity = 1.0;
                }
                noLoads[i].IsVisible = false;
            }
        }
        SaveUserDataToDatabase();
    }

    // Save the user data to the database
    private void SaveUserDataToDatabase()
    {
        SavedSessionDBHelper.Instance.InitAsync();
        var saveGames = App.CombinedVM.UserSaveGames.saveGames;
        foreach (var save in saveGames)
        {
            SavedSessionDBHelper.Instance.SaveDataAsync(save);
        }
    }


    // Button Clicked
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


    // Sound effect
    private async Task PlaySoundAsync(string fileName, double volume)
    {
        var player = App.CombinedVM.AudioPlayer.PlayAudioAsync(fileName, volume);
        if (player == null) return;
    }

    private async void DeleteButton1_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        App.CombinedVM.UserSaveGames.saveGames[0].isSave = "No";
        UpdateSave();
    }

    private async void DeleteButton2_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        App.CombinedVM.UserSaveGames.saveGames[1].isSave = "No";
        UpdateSave();


        SavedSessionDBHelper.Instance.InitAsync();
        var saveGames = App.CombinedVM.UserSaveGames.saveGames;
        foreach (var save in saveGames)
        {
            SavedSessionDBHelper.Instance.SaveDataAsync(save);
        }
        Console.WriteLine("💾 [App] บันทึกข้อมูลทั้งหมดก่อนออกแอป");
    }

    private async void DeleteButton3_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        App.CombinedVM.UserSaveGames.saveGames[2].isSave = "No";
        UpdateSave();
    }

    private async void SaveButton1_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        App.CombinedVM.UserSaveGames.saveGames[0].isSave = "Yes";
        UpdateSave();
    }

    private async void SaveButton2_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        App.CombinedVM.UserSaveGames.saveGames[1].isSave = "Yes";
        UpdateSave();

    }

    private async void SaveButton3_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        App.CombinedVM.UserSaveGames.saveGames[2].isSave = "Yes";
        UpdateSave();

    }
}