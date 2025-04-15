namespace BeyondHana
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Create the page route of the application
            var navigationPage = new NavigationPage(new Views.TitlePage());
            return new Window(navigationPage);
        }
    }
}