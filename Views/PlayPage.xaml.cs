namespace BeyondHana.Views;

public partial class PlayPage : ContentPage
{
	public PlayPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }
}