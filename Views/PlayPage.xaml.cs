namespace BeyondHana.Views;

public partial class PlayPage : ContentPage
{
	public PlayPage()
	{
		InitializeComponent();
        NewGameButton.Pressed += NewGameButton_Pressed;
        NewGameButton.Released += NewGameButton_Released;
        ContinueButton.Pressed += ContinueButton_Pressed;
        ContinueButton.Released += ContinueButton_Released;
        LoadGameButton.Pressed += LoadGameButton_Pressed;
        LoadGameButton.Released += LoadGameButton_Released;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void NewGameButton_Pressed(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        button.Source = "NewGame1_button.png";
        button.WidthRequest = 230;
        button.HeightRequest = 65;

        ChangeGridSizeRow1();
    }
    private async void NewGameButton_Released(object sender, EventArgs e)
    {
        var button = sender as ImageButton;

        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);

        await Task.Delay(100);

        button.Source = "NewGame2_button.png";
        button.WidthRequest = 147;
        button.HeightRequest = 65;

        ChangeGridSizeBack();

        // Navigate to the PlayPage
        //await Navigation.PushAsync(new Views.PlayPage());
    }

    private void ContinueButton_Pressed(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        button.Source = "Continue1_button.png";
        button.WidthRequest = 230;
        button.HeightRequest = 65;

        ChangeGridSizeRow2();
    }
    private async void ContinueButton_Released(object sender, EventArgs e)
    {
        var button = sender as ImageButton;

        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);

        await Task.Delay(100);

        button.Source = "Continue2_button.png";
        button.WidthRequest = 147;
        button.HeightRequest = 65;

        ChangeGridSizeBack();

        // Navigate to the PlayPage
        //await Navigation.PushAsync(new Views.PlayPage());
    }

    private void LoadGameButton_Pressed(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        button.Source = "LoadGame1_button.png";
        button.WidthRequest = 230;
        button.HeightRequest = 65;

        ChangeGridSizeRow3();
    }

    private async void LoadGameButton_Released(object sender, EventArgs e)
    {
        var button = sender as ImageButton;

        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);

        await Task.Delay(100);

        button.Source = "LoadGame2_button.png";
        button.WidthRequest = 147;
        button.HeightRequest = 65;

        ChangeGridSizeBack();

        // Navigate to the PlayPage
        //await Navigation.PushAsync(new Views.PlayPage());
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


    // Change the grid size of the rows
    private async Task ChangeGridSizeRow1()
    {
        Row1.Height = new GridLength(0.7, GridUnitType.Star);
    }
    private async Task ChangeGridSizeRow2()
    {
        Row2.Height = new GridLength(0.7, GridUnitType.Star);
    }
    private async Task ChangeGridSizeRow3()
    {
        Row3.Height = new GridLength(0.7, GridUnitType.Star);
    }
    // Change the grid size back to normal
    private async Task ChangeGridSizeBack()
    {
        Row1.Height = new GridLength(0.45, GridUnitType.Star);
        Row2.Height = new GridLength(0.45, GridUnitType.Star);
        Row3.Height = new GridLength(0.45, GridUnitType.Star);
    }
}