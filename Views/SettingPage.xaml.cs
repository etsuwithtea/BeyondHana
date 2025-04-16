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
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 200);
        await button.ScaleTo(1, 200);

        // Navigate back to the previous page
        await Navigation.PopAsync();
    }

    int SmallTextCheck = 0; 
    private async void SmallTextCheckButton_Clicked(object sender, EventArgs e)
    {
        if (SmallTextCheck == 0) { 
            SmallText_CheckBox.Source = "checkbox_2.png";
            SmallTextCheck = 1;
        }
        else
        {
            SmallText_CheckBox.Source = "checkbox_1.png";
            SmallTextCheck = 0;
        }
    }

    int NormalTextCheck = 0;
    private async void NormalTextCheckButton_Clicked(object sender, EventArgs e)
    {
        if (NormalTextCheck == 0)
        {
            NormalText_CheckBox.Source = "checkbox_2.png";
            NormalTextCheck = 1;
        }
        else
        {
            NormalText_CheckBox.Source = "checkbox_1.png";
            NormalTextCheck = 0;
        }
    }
}