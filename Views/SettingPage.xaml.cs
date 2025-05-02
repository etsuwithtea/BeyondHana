using BeyondHana.ViewModels;
namespace BeyondHana.Views;
public partial class SettingPage : ContentPage
{
    public SettingPage()
	{
		InitializeComponent();
        BindingContext = new CombinedVM(); // Set the BindingContext to CombinedVM

        BackButton.Pressed += BackButton_Pressed;
        BackButton.Released += BackButton_Released;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Hide the navigation bar
        NavigationPage.SetHasNavigationBar(this, false);

        // Set the initial state of the checkboxes based on the selected setting
        var combinedVM = BindingContext as CombinedVM;
        if (combinedVM == null) return;

        // Get the selected setting
        var setting = combinedVM.UserSetting.SelectedSetting;
        if (setting == null) return;

        if (setting.Textsize == 10)
        {
            SmallText_CheckBox.Source = "checkbox_2.png";
            NormalText_CheckBox.Source = "checkbox_1.png";
        }
        else if (setting.Textsize == 14)
        {
            SmallText_CheckBox.Source = "checkbox_1.png";
            NormalText_CheckBox.Source = "checkbox_2.png";
        }
    }


    private void SmallTextCheckButton_Clicked(object sender, EventArgs e)
    {
        // Set the initial state of the checkboxes based on the selected setting
        var combinedVM = BindingContext as CombinedVM;
        if (combinedVM == null) return;

        // Get the selected setting
        var setting = combinedVM.UserSetting.SelectedSetting;
        if (setting == null) return;

        // Set the text size to small
        setting.Textsize = 10;
        SmallText_CheckBox.Source = "checkbox_2.png";
        NormalText_CheckBox.Source = "checkbox_1.png";  
    }
    private void NormalTextCheckButton_Clicked(object sender, EventArgs e)
    {
        // Set the initial state of the checkboxes based on the selected setting
        var combinedVM = BindingContext as CombinedVM;
        if (combinedVM == null) return;

        // Get the selected setting
        var setting = combinedVM.UserSetting.SelectedSetting;
        if (setting == null) return;

        // Set the text size to normal
        setting.Textsize = 14;
        SmallText_CheckBox.Source = "checkbox_1.png";
        NormalText_CheckBox.Source = "checkbox_2.png";
    }


    private void BackButton_Pressed(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        button.Source = "back2_label.png";
    }
    private async void BackButton_Released(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 100);
        await button.ScaleTo(1, 100);
        await Task.Delay(100);
        // Reset the button appearance
        button.Source = "back1_label.png";

        // Navigate back to the previous page
        await Navigation.PopAsync();
    }
}