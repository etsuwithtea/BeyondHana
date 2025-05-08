using BeyondHana.ViewModels;
using Microsoft.Extensions.Logging;

namespace BeyondHana.Views;

public partial class StoryPage : ContentPage
{
    public static int currentChapter = 0;
    public StoryPage()
	{
		InitializeComponent();
        BindingContext = App.CombinedVM;

        NextButton.Pressed += NextButton_Pressed;
        NextButton.Released += NextButton_Released;

        LoadStory(currentChapter);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void LoadStory(int chapter)
    {       
        currentChapter = chapter;
        Preferences.Set("ChapterProgress", currentChapter);

        if (currentChapter <= 24)
        {
            var story = App.CombinedVM.Story;
            Background.Source = story.backgrounds[story.events[story.dialogues[currentChapter].event_id - 1].background_id - 1].file_path;
            TextContent.Text = story.dialogues[currentChapter].text;

            if (story.events[story.dialogues[currentChapter].event_id - 1].bgm_id != 0)
            {
                if (currentChapter == 0)
                {
                    App.CombinedVM.BGAudioPlayer.PlayAsync(story.bgms[story.events[story.dialogues[currentChapter].event_id - 1].bgm_id - 1].file_path, App.CombinedVM.UserSetting.SelectedSetting.Backgroundmusicpercent);
                }
                else if (story.events[story.dialogues[currentChapter].event_id - 1].bgm_id != story.events[story.dialogues[currentChapter - 1].event_id - 1].bgm_id)
                {
                    App.CombinedVM.BGAudioPlayer.PlayAsync(story.bgms[story.events[story.dialogues[currentChapter].event_id - 1].bgm_id - 1].file_path, App.CombinedVM.UserSetting.SelectedSetting.Backgroundmusicpercent);
                }
            }
            else
            {
                if (currentChapter == 0)
                {
                    App.CombinedVM.BGAudioPlayer.PlayAsync("soundtrack_wait.wav", App.CombinedVM.UserSetting.SelectedSetting.Backgroundmusicpercent);
                }
                else if (story.events[story.dialogues[currentChapter].event_id - 1].bgm_id != story.events[story.dialogues[currentChapter - 1].event_id - 1].bgm_id)
                {
                    App.CombinedVM.BGAudioPlayer.PlayAsync("soundtrack_wait.wav", App.CombinedVM.UserSetting.SelectedSetting.Backgroundmusicpercent);
                }
            }


            if (story.dialogues[currentChapter].is_narration == 0)
            {
                Character.IsVisible = false;
                WhoSpeak.Source = "subtitle_label.png";
            }
            if (story.dialogues[currentChapter].is_narration == 1)
            {
                var who = story.characters[story.dialogues[currentChapter].character_id - 1];
                Character.Source = who.file_path;
                Character.IsVisible = true;

                if (who.name == "Hana")
                {
                    WhoSpeak.Source = "hana_label.png";
                }
                if (who.name == "Akira")
                {
                    WhoSpeak.Source = "akira_label.png";
                }
                if (who.name == "Sakura")
                {
                    WhoSpeak.Source = "sakura_label.png";
                }
                if (who.name == "Emi")
                {
                    WhoSpeak.Source = "emi_label.png";
                }
                if (who.name == "Genji")
                {
                    WhoSpeak.Source = "genji_label.png";
                }
                WhoSpeak.IsVisible = true;
            }
        }
        else
        {
            await Navigation.PushAsync(new Views.Endpage());
        }
        
    }

    private async void NextButton_Pressed(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        button.Source = "storynext2_button.png";
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
    }
    private async void NextButton_Released(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);
        await Task.Delay(100);
        // Reset the button appearance
        button.Source = "storynext1_button.png";

        await Task.Delay(300);
        // Check if there are more chapters to load
        LoadStory(currentChapter + 1);
    }


    private async void SettingButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        await Navigation.PushAsync(new Views.SettingPage());
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Navigate to the Load and Save Game page
        await Navigation.PushAsync(new Views.LoadAndSaveGamePage(false));
    }

    private async void HomeButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Navigate to the tile page
        await Navigation.PushAsync(new Views.TitlePage());
    }

    // Sound effect
    private async Task PlaySoundAsync(string fileName, double volume)
    {
        var player = App.CombinedVM.AudioPlayer.PlayAudioAsync(fileName, volume);
        if (player == null) return;
    }
}