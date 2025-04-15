namespace BeyondHana.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void PlayButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 200);
        await button.ScaleTo(1, 200);

        // Change the grid size for the exit button
        ChangeGridSizeRow1();
        PlayButton.Source = "play1_button.png";
        PlayButton.WidthRequest = 230;
        PlayButton.HeightRequest = 65;
        await Task.Delay(300);

        // Change the grid size back
        PlayButton.Source = "play2_button.png";
        PlayButton.WidthRequest = 147;
        PlayButton.HeightRequest = 45;
        ChangeGridSizeBack();
    }

    private async void SettingButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 200);
        await button.ScaleTo(1, 200);

        // Change the grid size for the exit button
        ChangeGridSizeRow2();
        SettingButton.Source = "setting1_button.png";
        SettingButton.WidthRequest = 250;
        SettingButton.HeightRequest = 65;
        await Task.Delay(300);


        // Change the grid size back
        SettingButton.Source = "setting2_button.png";
        SettingButton.WidthRequest = 158;
        SettingButton.HeightRequest = 45;
        ChangeGridSizeBack();
    }

    private async void ExitButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 200);
        await button.ScaleTo(1, 200);

        // Change the grid size for the exit button
        ChangeGridSizeRow3();
        ExitButton.Source = "exit1_button.png";
        ExitButton.WidthRequest = 180;
        ExitButton.HeightRequest = 65;
        await Task.Delay(300);

        // Navigate to the ClosePage
        await Navigation.PushAsync(new Views.ClosePage());

        // Change the grid size back
        ExitButton.Source = "exit2_button.png";
        ExitButton.WidthRequest = 90;
        ExitButton.HeightRequest = 45;
        ChangeGridSizeBack();
    }
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
    private async Task ChangeGridSizeBack()
    {
        Row1.Height = new GridLength(0.45, GridUnitType.Star);
        Row2.Height = new GridLength(0.45, GridUnitType.Star);
        Row3.Height = new GridLength(0.45, GridUnitType.Star);
    }
}