namespace BeyondHana.Views;
public partial class TitlePage : ContentPage
{
	public TitlePage()
	{
		InitializeComponent();
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
        await button.ScaleTo(1.0, 150, Easing.SpringOut);

        // Navigate to the HomePage
        await Navigation.PushAsync(new Views.HomePage());
    }
}