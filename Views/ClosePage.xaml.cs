namespace BeyondHana.Views;

public partial class ClosePage : ContentPage
{
	public ClosePage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Navigate back to the previous page
        await Navigation.PopAsync();
    }

    private async void CloseButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        // Soft Bounce Animation
        await button.ScaleTo(0.85, 150, Easing.CubicOut);
        await button.ScaleTo(1.05, 150, Easing.CubicInOut);
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Close the application
        Application.Current.Quit(); 
    }
}