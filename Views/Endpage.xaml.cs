namespace BeyondHana.Views;

public partial class Endpage : ContentPage
{
    // Constructor
    public Endpage()
	{
		InitializeComponent();
        GoToTitlePage();
    }
    // Override OnAppearing to hide the navigation bar
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    // go to title page after 4 seconds
    private async void GoToTitlePage()
    {
        await Task.Delay(4000); 
        await Navigation.PushAsync(new Views.TitlePage());
    }
}