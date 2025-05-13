namespace BeyondHana.Views;

public partial class BlackScreen : ContentPage
{
	public BlackScreen()
	{
		InitializeComponent();
        GoToStoryPage();
    }
   protected override void OnAppearing()
   {
        base.OnAppearing();
        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
   }

    // go to story page after 3 seconds
    private async void GoToStoryPage()
    {
        await Task.Delay(3000);
        await Navigation.PushAsync(new Views.StoryPage());
    }
}