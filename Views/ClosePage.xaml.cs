namespace BeyondHana.Views;

public partial class ClosePage : ContentPage
{
	public ClosePage()
	{
		InitializeComponent();
        // Set button events
        BackButton.Pressed += BackButton_Pressed;
        BackButton.Released += BackButton_Released;
        CloseButton.Pressed += CloseButton_Pressed;
        CloseButton.Released += CloseButton_Released;
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
        button.Source = "back1_button.png";
        button.WidthRequest = 275;
        button.HeightRequest = 100;

    }
    private async void BackButton_Released(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);
        await Task.Delay(100);
        // Reset the button appearance
        button.Source = "back2_button.png";
        button.WidthRequest = 180;
        button.HeightRequest = 70;

        // Navigate back to the previous page
        await Navigation.PopAsync();
    }


    private void CloseButton_Pressed(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        button.Source = "close1_button.png";
        button.WidthRequest = 275;
        button.HeightRequest = 100;

    }
    private async void CloseButton_Released(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);
        await Task.Delay(100);
        // Reset the button appearance
        button.Source = "close2_button.png";
        button.WidthRequest = 180;
        button.HeightRequest = 70;

        // Close the application
        Application.Current.Quit();
    }
}