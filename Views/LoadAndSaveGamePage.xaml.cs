using BeyondHana.Data;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace BeyondHana.Views;

public partial class LoadAndSaveGamePage : ContentPage
{
    private bool CheckIsLoadGamePageOn;
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
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

    // Is Visible Content
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
                if (saveGames[i].current_event_id != 999999) // if have event next
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
                if (saveGames[i].current_event_id == 999999)
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
        SaveGameDBHelper.Instance.InitAsync();
        var saveGames = App.CombinedVM.UserSaveGames.saveGames;
        foreach (var save in saveGames)
        {
            SaveGameDBHelper.Instance.SaveDataAsync(save);
        }
    }


    // Button Clicked
    private async void PlayButton1_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Load game
        var loadgame = App.CombinedVM.UserSaveGames.saveGames[0];
        StoryPage.currentChapter = loadgame.current_event_id;

        // Navigate to the StoryPage
        await Navigation.PushAsync(new Views.StoryPage());
    }

    private async void PlayButton2_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Load game
        var loadgame = App.CombinedVM.UserSaveGames.saveGames[1];
        StoryPage.currentChapter = loadgame.current_event_id;

        // Navigate to the StoryPage
        await Navigation.PushAsync(new Views.StoryPage());
    }

    private async void PlayButton3_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Load game
        var loadgame = App.CombinedVM.UserSaveGames.saveGames[2];
        StoryPage.currentChapter = loadgame.current_event_id;

        // Navigate to the StoryPage
        await Navigation.PushAsync(new Views.StoryPage());
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

        // Delete save game 
        var savegame = App.CombinedVM.UserSaveGames.saveGames[0];
        savegame.current_event_id = 999999;
        savegame.updated_at = null;
        savegame.created_at = null; 
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

        // Delete save game
        var savegame = App.CombinedVM.UserSaveGames.saveGames[1];
        savegame.current_event_id = 999999;
        savegame.updated_at = null;
        savegame.created_at = null;
        UpdateSave();

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

        // Delete save game
        var savegame = App.CombinedVM.UserSaveGames.saveGames[2];
        savegame.current_event_id = 999999;
        savegame.updated_at = null;
        savegame.created_at = null;
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

        // Save game
        var savegame = App.CombinedVM.UserSaveGames.saveGames[0];
        savegame.current_event_id = StoryPage.currentChapter;

        ToastDuration duration = ToastDuration.Short;
        if (savegame.current_event_id != 999999)
        {
         
            if (savegame.created_at == null)
            {
                savegame.created_at = DateTime.Now;

                var toast = Toast.Make($"Save แล้วนะ เวลา : {savegame.created_at}", duration, 14);
                await toast.Show(cancellationTokenSource.Token);

            }
            else
            {
                savegame.updated_at = DateTime.Now;
           
                var toast = Toast.Make($"Save แล้วแต่ทับอันเดิมนะ เวลา : {savegame.updated_at}", duration, 14);
                await toast.Show(cancellationTokenSource.Token);
            }
            savegame.updated_at = DateTime.Now;
        }   
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

        // Save game
        var savegame = App.CombinedVM.UserSaveGames.saveGames[1];
        savegame.current_event_id = StoryPage.currentChapter;

        ToastDuration duration = ToastDuration.Short;
        if (savegame.current_event_id != 999999)
        {

            if (savegame.created_at == null)
            {
                savegame.created_at = DateTime.Now;

                var toast = Toast.Make($"Save แล้วนะ เวลา : {savegame.created_at}", duration, 14);
                await toast.Show(cancellationTokenSource.Token);

            }
            else
            {
                savegame.updated_at = DateTime.Now;

                var toast = Toast.Make($"Save แล้วแต่ทับอันเดิมนะ เวลา : {savegame.updated_at}", duration, 14);
                await toast.Show(cancellationTokenSource.Token);
            }
            savegame.updated_at = DateTime.Now;
        }
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

        //  Save game
        var savegame = App.CombinedVM.UserSaveGames.saveGames[2];
        savegame.current_event_id = StoryPage.currentChapter;

        ToastDuration duration = ToastDuration.Short;
        if (savegame.current_event_id != 999999)
        {

            if (savegame.created_at == null)
            {
                savegame.created_at = DateTime.Now;

                var toast = Toast.Make($"Save แล้วนะ เวลา : {savegame.created_at}", duration, 14);
                await toast.Show(cancellationTokenSource.Token);

            }
            else
            {
                savegame.updated_at = DateTime.Now;

                var toast = Toast.Make($"Save แล้วแต่ทับอันเดิมนะ เวลา : {savegame.updated_at}", duration, 14);
                await toast.Show(cancellationTokenSource.Token);
            }
            savegame.updated_at = DateTime.Now;
        }
        UpdateSave(); ;

    }

    // save game slot 1 tapped
    private async void saveslot1_label_Tapped(object sender, TappedEventArgs e)
    {
        // Animation Clicked
        var savegame = App.CombinedVM.UserSaveGames.saveGames[0];
        if (savegame.current_event_id != 999999)
        {
            if (sender is Grid grid)
            {
                grid.IsEnabled = false;

                try
                {
                    await grid.ScaleTo(0.85, 100, Easing.CubicOut);
                    await grid.ScaleTo(1.05, 100, Easing.CubicInOut);

                    await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);

                    await grid.ScaleTo(1.0, 100, Easing.SpringOut);


                    ToastDuration duration = ToastDuration.Short;
                    var toast = Toast.Make($"คุณ save ครั้งล่าสุดเมื่อ : {savegame.updated_at}", duration, 14);
                    await toast.Show(cancellationTokenSource.Token);
                }
                finally
                {
                    grid.IsEnabled = true;
                }
            }
        }       
    }
    // save game slot 2 tapped
    private async void saveslot2_label_Tapped(object sender, TappedEventArgs e)
    {
        // Animation Clicked
        var savegame = App.CombinedVM.UserSaveGames.saveGames[1];
        if (savegame.current_event_id != 999999)
        {
            if (sender is Grid grid)
            {
                grid.IsEnabled = false;

                try
                {
                    await grid.ScaleTo(0.85, 100, Easing.CubicOut);
                    await grid.ScaleTo(1.05, 100, Easing.CubicInOut);

                    await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);

                    await grid.ScaleTo(1.0, 100, Easing.SpringOut);


                    ToastDuration duration = ToastDuration.Short;
                    var toast = Toast.Make($"คุณ save ครั้งล่าสุดเมื่อ : {savegame.updated_at}", duration, 14);
                    await toast.Show(cancellationTokenSource.Token);
                }
                finally
                {
                    grid.IsEnabled = true;
                }
            }
        }
    }
    // save game slot 3 tapped
    private async void saveslot3_label_Tapped(object sender, TappedEventArgs e)
    {
        // Animation Clicked
        var savegame = App.CombinedVM.UserSaveGames.saveGames[2];
        if (savegame.current_event_id != 999999)
        {
            if (sender is Grid grid)
            {
                grid.IsEnabled = false;

                try
                {
                    await grid.ScaleTo(0.85, 100, Easing.CubicOut);
                    await grid.ScaleTo(1.05, 100, Easing.CubicInOut);

                    await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);

                    await grid.ScaleTo(1.0, 100, Easing.SpringOut);


                    ToastDuration duration = ToastDuration.Short;
                    var toast = Toast.Make($"คุณ save ครั้งล่าสุดเมื่อ : {savegame.updated_at}", duration, 14);
                    await toast.Show(cancellationTokenSource.Token);
                }
                finally
                {
                    grid.IsEnabled = true;
                }
            }
        }
    }
}