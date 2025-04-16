namespace BeyondHana.Views;

public partial class SettingPage : ContentPage
{
	public SettingPage()
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
        // Navigate back to the previous page
        await Navigation.PopAsync();
    }
}