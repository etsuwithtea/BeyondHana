using BeyondHana.ViewModels;
using BeyondHana.Data;
using BeyondHana.Views;
namespace BeyondHana
{
    public partial class App : Application
    {
        public static CombinedVM CombinedVM { get; private set; }
        public App()
        {
            InitializeComponent();
            CombinedVM = new CombinedVM();
            CombinedVM.BGAudioPlayer.PlayAsync("soundtrack_wait.wav", CombinedVM.UserSetting.SelectedSetting.Backgroundmusicpercent);
            Preferences.Get("ChapterProgress", 0);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Create the page route of the application
            var navigationPage = new NavigationPage(new Views.TitlePage());
            return new Window(navigationPage);
        }
        // This method is called when the application is on  sleep
        protected override void OnSleep()
        {
            SaveUserDataToDatabase();
            CombinedVM.BGAudioPlayer.Stop();
            Preferences.Set("ChapterProgress", StoryPage.currentChapter);
        }

        // / This method is called when the application is resumed from sleep
        protected override void OnResume()
        {
            base.OnResume();

            var setting = CombinedVM.UserSetting.SelectedSetting;
            CombinedVM.BGAudioPlayer.PlayAsync(Preferences.Get("currentBGAudioFile", "soundtrack_wait.wav"), setting.Backgroundmusicpercent);
            Preferences.Get("ChapterProgress", 0);
        }

        private void SaveUserDataToDatabase()
        {
            SaveGameDBHelper.Instance.InitAsync();
            var saveGames = CombinedVM.UserSaveGames.saveGames;
            foreach (var save in saveGames)
            {
                SaveGameDBHelper.Instance.SaveDataAsync(save);
            }
        }

    }
}