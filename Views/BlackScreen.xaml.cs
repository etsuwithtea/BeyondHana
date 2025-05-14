namespace BeyondHana.Views;

public partial class BlackScreen : ContentPage
{
	public BlackScreen()
	{
		InitializeComponent();
        ClosePage();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void ClosePage()
    {
        await Task.Delay(3000);
        await Navigation.PopAsync();
    }
}