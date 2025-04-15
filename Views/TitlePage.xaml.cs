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
        await button.ScaleTo(0.95, 200);
        await button.ScaleTo(1, 200);

        // Navigate to the HomePage
        await Navigation.PushAsync(new Views.HomePage());
    }
}