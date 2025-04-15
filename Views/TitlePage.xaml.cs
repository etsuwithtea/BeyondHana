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
}