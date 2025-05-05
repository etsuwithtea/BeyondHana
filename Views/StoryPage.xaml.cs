namespace BeyondHana.Views;

public partial class StoryPage : ContentPage
{
	public StoryPage()
	{
		InitializeComponent();
        BindingContext = App.CombinedVM;

        NextButton.Pressed += NextButton_Pressed;
        NextButton.Released += NextButton_Released;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void NextButton_Pressed(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        button.Source = "storynext2_button.png";
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

        // Navigate back to the previous page
        await Navigation.PopAsync();
    }


    private async void SettingButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
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
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Navigate to the PlayPage
        await Navigation.PushAsync(new Views.LoadAndSaveGamePage(false));
    }

    private async void InventoryButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);
    }
}