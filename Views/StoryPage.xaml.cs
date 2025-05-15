namespace BeyondHana.Views;

public partial class StoryPage : ContentPage
{
    // current chapter
    public static int currentChapter = 0;

    // is black screen
    public static int isblackscreen = 0;

    // Constructor
    public StoryPage()
	{
		InitializeComponent();
        BindingContext = App.CombinedVM;

        NextButton.Pressed += NextButton_Pressed;
        NextButton.Released += NextButton_Released;

        IsNormalDialogue.IsVisible = true;
        LoadStory(currentChapter);
    }
    // OnAppearing method
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    // Load the story
    private async void LoadStory(int chapter)
    {       
        currentChapter = chapter;
        Preferences.Set("ChapterProgress", currentChapter);
        var story = App.CombinedVM.Story;

        if (currentChapter <= story.dialogues.Count - 1)
        {
            if (story.dialogues[currentChapter].is_black_screen == 1)
            {
                isblackscreen = 1;
            }
            else if (story.dialogues[currentChapter].is_black_screen == 0)
            {
                isblackscreen = 0;
            }

            if (isblackscreen == 1)
            {
                await Navigation.PushAsync(new Views.BlackScreen());
            }

            // soundtrack
            int currentEventBgmId = story.events[story.dialogues[currentChapter].event_id - 1].bgm_id;
            int previousEventBgmId = currentChapter > 0 ? story.events[story.dialogues[currentChapter - 1].event_id - 1].bgm_id : -1;

            if (currentChapter == 0 || currentEventBgmId != previousEventBgmId)
            {
                string filePath;

                if (currentEventBgmId != 0)
                {
                    filePath = story.bgms[currentEventBgmId - 1].file_path;
                }
                else
                {
                    filePath = "soundtrack_wait.wav";
                }

                await App.CombinedVM.BGAudioPlayer.PlayAsync(filePath, App.CombinedVM.UserSetting.SelectedSetting.Backgroundmusicpercent);
            }


            if (story.dialogues[currentChapter].is_choice == 1)
            {
                IsNormalDialogue.IsVisible = false;
                IsChoiceDialogue.IsVisible = true;

                Background.Source = story.backgrounds[story.events[story.dialogues[currentChapter].event_id - 1].background_id - 1].file_path;
                TextTitle.Text = story.dialogues[currentChapter].text;

                if (story.dialogues[currentChapter].is_narration == 1)
                {
                    Character.IsVisible = false;
                    WhoSpeak.IsVisible = false;
                }
                if (story.dialogues[currentChapter].is_narration == 0)
                {
                    var who = story.characters[story.dialogues[currentChapter].character_id - 1];
                    Character.Source = who.file_path;
                    Character.IsVisible = true;
                    Character.HorizontalOptions = LayoutOptions.Start;
                    Character.HeightRequest = 300;
                }


                if (story.choices.Where(x => x.dialogue_id == currentChapter + 1).Count() == 2)
                {
                    var nextChoices = story.choices.Where(x => x.dialogue_id == currentChapter + 1).ToList();

                    TextChoice1.Text = nextChoices[0].choice_text;
                    TextChoice2.Text = nextChoices[1].choice_text;
                    TextChoice2.IsVisible = true;
                    TextChoice2.IsVisible = true;
                }

            }
            else if (story.dialogues[currentChapter].is_choice == 0)
            {
                IsNormalDialogue.IsVisible = true;
                IsChoiceDialogue.IsVisible = false;

                Background.Source = story.backgrounds[story.events[story.dialogues[currentChapter].event_id - 1].background_id - 1].file_path;
                TextContent.Text = story.dialogues[currentChapter].text;

                if (story.dialogues[currentChapter].is_narration == 1)
                {
                    Character.IsVisible = false;
                    WhoSpeak.IsVisible = false;
                }
                if (story.dialogues[currentChapter].is_narration == 0)
                {
                    var who = story.characters[story.dialogues[currentChapter].character_id - 1];
                    Character.Source = who.file_path;
                    Character.HorizontalOptions = LayoutOptions.Center;
                    Character.IsVisible = true;
                    Character.HeightRequest = 400;

                    if (who.name == "hana_normal_1")
                    {
                        WhoSpeak.Source = "hana_label.png";
                    }
                    else if (who.name == "hana_normal_2")
                    {
                        WhoSpeak.Source = "hana_label.png";
                    }
                    else if (who.name == "hana_awkward")
                    {
                        WhoSpeak.Source = "hana_label.png";
                    }
                    else if (who.name == "hana_happy")
                    {
                        WhoSpeak.Source = "hana_label.png";
                    }
                    else if (who.name == "hana_sad")
                    {
                        WhoSpeak.Source = "hana_label.png";
                    }
                    else if (who.name == "hana_shy")
                    {
                        WhoSpeak.Source = "hana_label.png";
                    }
                    else if (who.name == "hana_suspect")
                    {
                        WhoSpeak.Source = "hana_label.png";
                    }
                    else if (who.name == "akira")
                    {
                        WhoSpeak.Source = "akira_label.png";
                    }
                    else if (who.name == "sakura_1")
                    {
                        WhoSpeak.Source = "sakura_label.png";
                    }
                    else if (who.name == "sakura_2")
                    {
                        WhoSpeak.Source = "sakura_label.png";
                    }
                    else if (who.name == "emi")
                    {
                        WhoSpeak.Source = "emi_label.png";
                    }
                    else if (who.name == "genji")
                    {
                        WhoSpeak.Source = "genji_label.png";
                    }
                    else if (who.name == "police")
                    {
                        WhoSpeak.Source = "police_label.png";
                    }
                    else if (who.name == "akira mom")
                    {
                        WhoSpeak.Source = "akiramom_label";
                    }
                    WhoSpeak.IsVisible = true;
                }
            }
        }
        else
        {
            await Navigation.PushAsync(new Views.Endpage());
        }
    }

    // Next button event handlers
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
        var story = App.CombinedVM.Story;
        if (story.dialogues[currentChapter].dialogue_to != 0)
        {
            currentChapter = story.dialogues[currentChapter].dialogue_to - 1;
        }
        else if (story.dialogues[currentChapter].dialogue_to == 0)
        {
            currentChapter += 1;
        }
        LoadStory(currentChapter);
    }

    // Setting button event handlers
    private async void SettingButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Navigate to the Setting page
        await Navigation.PushAsync(new Views.SettingPage());
    }

    // Save button event handlers
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

    // Home button event handlers
    private async void HomeButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        App.CombinedVM.BGAudioPlayer.PlayAsync("soundtrack_wait.wav", App.CombinedVM.UserSetting.SelectedSetting.Backgroundmusicpercent);
        // Navigate to the tile page
        await Navigation.PushAsync(new Views.TitlePage());
    }

    // Sound effect
    private async Task PlaySoundAsync(string fileName, double volume)
    {
        var player = App.CombinedVM.AudioPlayer.PlayAudioAsync(fileName, volume);
        if (player == null) return;
    }

    // Choice button event handlers
    private async void TextChoice1_Tapped(object sender, TappedEventArgs e)
    {
        var story = App.CombinedVM.Story;

        if (sender is Border border)
        {
            border.IsEnabled = false;

            try
            {
                await border.ScaleTo(0.85, 100, Easing.CubicOut);
                await border.ScaleTo(1.05, 100, Easing.CubicInOut);
                await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
                await border.ScaleTo(1.0, 100, Easing.SpringOut);

                var nextChoices = story.choices.Where(x => x.dialogue_id == currentChapter + 1).ToList();
                currentChapter = nextChoices[0].next_dialogue_id - 1;
                LoadStory(currentChapter);
            }
            finally
            {
                border.IsEnabled = true;
            }
        }
    }
    private async void TextChoice2_Tapped(object sender, TappedEventArgs e)
    {
        var story = App.CombinedVM.Story;

        if (sender is Border border)
        {
            border.IsEnabled = false;

            try
            {
                await border.ScaleTo(0.85, 100, Easing.CubicOut);
                await border.ScaleTo(1.05, 100, Easing.CubicInOut);
                await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
                await border.ScaleTo(1.0, 100, Easing.SpringOut);

                var nextChoices = story.choices.Where(x => x.dialogue_id == currentChapter + 1).ToList();
                currentChapter = nextChoices[1].next_dialogue_id - 1;
                LoadStory(currentChapter);
            }
            finally
            {
                border.IsEnabled = true;
            }
        }
    }
    private async void ScrollViewTextChoice1_Tapped(object sender, TappedEventArgs e)
    {
        var story = App.CombinedVM.Story;

        if (sender is ScrollView scrollView)
        {
            scrollView.IsEnabled = false;

            try
            {
                // Animation: scale content 
                await scrollView.ScaleTo(0.95, 100, Easing.CubicOut);
                await scrollView.ScaleTo(1.05, 100, Easing.CubicInOut);
                await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
                await scrollView.ScaleTo(1.0, 100, Easing.SpringOut);

                // Logic: change story
                var nextChoices = story.choices.Where(x => x.dialogue_id == currentChapter + 1).ToList();
                currentChapter = nextChoices[0].next_dialogue_id - 1;
                LoadStory(currentChapter);
            }
            finally
            {
                scrollView.IsEnabled = true;
            }
        }
    }

    private async void ScrollViewTextChoice2_Tapped(object sender, TappedEventArgs e)
    {
        var story = App.CombinedVM.Story;

        if (sender is ScrollView scrollView)
        {
            scrollView.IsEnabled = false;

            try
            {
                // Animation: scale content 
                await scrollView.ScaleTo(0.95, 100, Easing.CubicOut);
                await scrollView.ScaleTo(1.05, 100, Easing.CubicInOut);
                await PlaySoundAsync("buttonclicksound.mp3", App.CombinedVM.UserSetting.SelectedSetting.Soundeffectpercent);
                await scrollView.ScaleTo(1.0, 100, Easing.SpringOut);

                // Logic: change story
                var nextChoices = story.choices.Where(x => x.dialogue_id == currentChapter + 1).ToList();
                currentChapter = nextChoices[1].next_dialogue_id - 1;
                LoadStory(currentChapter);
            }
            finally
            {
                scrollView.IsEnabled = true;
            }
        }
    }

}