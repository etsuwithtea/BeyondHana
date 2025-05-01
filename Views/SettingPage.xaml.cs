using BeyondHana.ViewModels;

namespace BeyondHana.Views;

public partial class SettingPage : ContentPage
{
    public SettingPage()
	{
		InitializeComponent();
        BindingContext = new CombinedVM(); // Set the BindingContext to CombinedVM
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

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        // Animation Clicked
        var button = sender as ImageButton;
        await button.ScaleTo(0.95, 200);
        await button.ScaleTo(1, 200);

        // Navigate back to the previous page
        await Navigation.PopAsync();
    }


    private void SmallTextCheckButton_Clicked(object sender, EventArgs e)
    {
        // Set the initial state of the checkboxes based on the selected setting
        var combinedVM = BindingContext as CombinedVM;
        if (combinedVM == null) return;

        // Get the selected setting
        var setting = combinedVM.UserSetting.SelectedSetting;
        if (setting == null) return;

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

        setting.Textsize = 14;
        SmallText_CheckBox.Source = "checkbox_1.png";
        NormalText_CheckBox.Source = "checkbox_2.png";
    }
}