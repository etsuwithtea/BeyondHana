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
        await button.ScaleTo(0.95, 200);
        await button.ScaleTo(1, 200);

        // Navigate back to the previous page
        await Navigation.PopAsync();
    }

    private async void CloseButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 200);
        await button.ScaleTo(1, 200);

        // Close the application
        Application.Current.Quit(); 
    }
}