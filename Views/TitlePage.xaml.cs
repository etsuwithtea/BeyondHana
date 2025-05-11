namespace BeyondHana.Views;
using BeyondHana.ViewModels;
using CommunityToolkit.Maui.Views;
using Plugin.Maui.Audio;

public partial class TitlePage : ContentPage
{
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


        //foreach (var item in App.CombinedVM.Story.backgrounds)
        //{
        //    Console.WriteLine(item.background_id);
        //    Console.WriteLine(item.file_path);
        //    Console.WriteLine(item.description);
        //}

        //foreach (var item in App.CombinedVM.Story.bgms)
        //{
        //    Console.WriteLine(item.bgm_id);
        //    Console.WriteLine(item.file_path);
        //    Console.WriteLine(item.description);
        //}

        //foreach (var item in App.CombinedVM.Story.characters)
        //{
        //    Console.WriteLine(item.character_id);
        //    Console.WriteLine(item.name);
        //    Console.WriteLine(item.file_path);           
        //}

        //foreach (var item in App.CombinedVM.Story.choices)
        //{
        //    Console.WriteLine(item.choice_id);
        //    Console.WriteLine(item.event_id);
        //    Console.WriteLine(item.choice_text);
        //    Console.WriteLine(item.next_dialogue_id);
        //    Console.WriteLine(item.dialogue_id);
        //}

        //foreach (var item in App.CombinedVM.Story.dialogues)
        //{
        //    Console.WriteLine(item.dialogue_id);
        //    Console.WriteLine(item.event_id);
        //    Console.WriteLine(item.chracter_id);
        //    Console.WriteLine(item.text);
        //    Console.WriteLine(item.is_narration);
        //    Console.WriteLine(item.is_choice);
        //}

        //foreach (var item in App.CombinedVM.Story.events)
        //{
        //    Console.WriteLine(item.event_id);
        //    Console.WriteLine(item.background_id);
        //    Console.WriteLine(item.content);
        //    Console.WriteLine(item.bgm_id);
        //}
    }

    // Sound effect
    private async Task PlaySoundAsync(string fileName, double volume)
    {
        var player = App.CombinedVM.AudioPlayer.PlayAudioAsync(fileName, volume);
        if (player == null) return;
    }
}