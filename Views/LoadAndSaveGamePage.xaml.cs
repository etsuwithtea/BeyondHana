namespace BeyondHana.Views;

public partial class LoadAndSaveGamePage : ContentPage
{
	public LoadAndSaveGamePage()
	{
		InitializeComponent();
        BackButton.Pressed += BackButton_Pressed;
        BackButton.Released += BackButton_Released;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void BackButton_Pressed(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        button.Source = "back2_label.png";
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
}