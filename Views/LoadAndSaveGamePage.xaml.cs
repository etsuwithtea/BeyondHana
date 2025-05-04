using BeyondHana.ViewModels;
using BeyondHana.Data;
namespace BeyondHana.Views;

public partial class LoadAndSaveGamePage : ContentPage
{
	public LoadAndSaveGamePage()
	{
		InitializeComponent();
        BackButton.Pressed += BackButton_Pressed;
        BackButton.Released += BackButton_Released;

        BindingContext = App.CombinedVM;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);

        
        UpdateSave();
    }
    private void UpdateSave()
    {
        Console.WriteLine(App.CombinedVM.UserSaveGames.saveGames[0].isSave);
        Console.WriteLine(App.CombinedVM.UserSaveGames.saveGames[1].isSave);
        Console.WriteLine(App.CombinedVM.UserSaveGames.saveGames[2].isSave);

        var saveGames = App.CombinedVM.UserSaveGames.saveGames;

        if (saveGames.Count < 3)
        {
            Console.WriteLine("❌ ไม่พบข้อมูล SaveGames ครบ 3 ช่อง");
            return;
        }

        // อาร์เรย์ของ Grid และ NoLoad ที่จับคู่กัน
        var gridLoads = new[] { GridLoad1, GridLoad2, GridLoad3 };
        var noLoads = new[] { NoLoad1, NoLoad2, NoLoad3 };

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Slot {i + 1} isSave = {saveGames[i].isSave}");

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


        UserSaveGameDatabaseHelper.Instance.InitAsync();
        var saveGames = App.CombinedVM.UserSaveGames.saveGames;
        foreach (var save in saveGames)
        {
            UserSaveGameDatabaseHelper.Instance.SaveNoteAsync(save);
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

}