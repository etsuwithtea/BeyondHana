namespace BeyondHana.Views;

public partial class Endpage : ContentPage
{
	public Endpage()
	{
		InitializeComponent();
        GoToTitlePage();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void GoToTitlePage()
    {
        await Task.Delay(4000); 
        await Navigation.PushAsync(new Views.TitlePage());
    }
}